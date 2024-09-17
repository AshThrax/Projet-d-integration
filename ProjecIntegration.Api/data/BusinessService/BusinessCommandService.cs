
using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Azure;
using DataInfraTheather.Services;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;
using Microsoft.Extensions.Logging;

namespace DataInfraTheather.BusinessService
{
    public class BusinessCommandService : IBusinessCommandService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IRepresentationRepository _representationRepository;
        private readonly IPieceRepository _piecerepository;
        private readonly ISalleDeTheatreRepository _sallerepository;
        private readonly ISiegeCommandRepository _siegeCommandRepository;
        private readonly ISiegeRepository _siegeRepository;
        private readonly ILogger<BusinessCommandService> _logger;
        private readonly IMapper _mapper;

        public BusinessCommandService(
            ICommandRepository commandRepository,
            IPieceRepository pieceRepository,
            ISalleDeTheatreRepository sallerepository,
            IMapper mapper,
            IRepresentationRepository representationRepository,
            ISiegeRepository siegeRepository,
            ISiegeCommandRepository siegeCommandRepository,
            ILogger<BusinessCommandService> logger
            )
        {
            _mapper = mapper;
            _sallerepository = sallerepository;
            _piecerepository = pieceRepository;
            _commandRepository = commandRepository;
            _representationRepository = representationRepository;
            _siegeRepository=siegeRepository;
            _siegeCommandRepository=siegeCommandRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<CommandDto>> DeleteCommand(int id)
        {
            ServiceResponse<CommandDto> response = new();
            try 
            {
                
                Command getEntity = await _commandRepository.GetById(id);
                if (getEntity != null)
                {
                    await _commandRepository.Delete(id);
                    response.Success = true;
                    response.Message = "opéraiton réussi";
                    response.Errortype=Domain.Enum.Errortype.Good;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                response.Success = true;
                response.Message = $"Une Erreur a eu lieu : message ={ex.Message}";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<List<TicketDto>>> GenerateCommandTicket(int CommandeId)
        {
            ServiceResponse<List<TicketDto>> response = new();
            Command command = await  _commandRepository.GetCommand(CommandeId);
            try
            {
                
                Representation representation = await _representationRepository.GetById(command.IdRepresentation);//récuperation de la seance 
                int PieceID = representation.PieceId;    //recuperation de la piece
                var Piece = await _piecerepository.GetById(PieceID);
                var salle = await _sallerepository.GetById(representation.SalledeTheatreId);
                var DateToString = representation.Seance;
                //génération du ticket
                response.Data= TicketGenerator.GetTicketUser(command.NombreDePlace, Piece.Titre, salle.Name,representation.Id,DateToString);
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Data = new List<TicketDto>();
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            return response;
        }

        public async Task<ServiceResponse<CommandDto>> AddCommand( AddCommandDto command)
        {
            ServiceResponse<CommandDto> response = new();
            try
            {
                //vérification du nombre de place a ssocié avec la commande et la representation
               if (command != null)
                {
                    Representation vérification =await _representationRepository.GetById(command.IdRepresentation);
                    SalleDeTheatre salle = await _sallerepository.GetById(vérification.SalleDeTheatre.Id);
                    int maxPlace= salle.PlaceMax;
                    if (vérification.PlaceCurrent + command.NombreDePlace <= vérification.PlaceMaximum)
                    {
                        //validation
                        //conversion Dto
                        Command Conversion = _mapper.Map<Command>(command);
                        Conversion =await _commandRepository.AddCommand(Conversion);


                        //inserer les sieges a la commande 
                        IEnumerable<Siege> addSiegeToCommand = await _siegeRepository.GetFromListIds(command.SiegeIds);

                        foreach (Siege Item in addSiegeToCommand)
                        {
                            SiegeCommand siegeCommand = new SiegeCommand 
                            {
                                CommandId=Conversion.Id,
                                Command = Conversion,
                                SiegeId=Item.Id,
                                Siege=Item,
                            };

                            await _siegeCommandRepository.Insert(siegeCommand);
                            response.Success = true;
                            response.Message = $"Opération réussi";
                            response.Errortype = Domain.Enum.Errortype.Good;
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = $"aucune PLace n'est disponible ";
                        response.Errortype = Domain.Enum.Errortype.Other;
                    }

                } 
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                response.Success = false;
                response.Message = $"Une Erreur a eu lieu : message ={ex.Message}";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CommandDto>>> GetAllCommand()
        {
            ServiceResponse<IEnumerable<CommandDto>> response = new();
            try
            { 
                var getAll = await _commandRepository.GetAll();
                response.Data= _mapper.Map<IEnumerable<CommandDto>>(getAll);
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype= Domain.Enum.Errortype.Good;
            }
            catch (Exception )
            {
                response.Data = new List<CommandDto>();
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<CommandDto>> GetCommand(int id)
        {
            ServiceResponse<CommandDto> response = new();
            try 
            { 
                    Command getEntity = await _commandRepository.GetById(id);
                response.Data= _mapper.Map<CommandDto>(getEntity);
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch(Exception )
            {
                response.Data = new();
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CommandDto>>> GetCommandUSer(string Auth)
        {
            ServiceResponse<IEnumerable<CommandDto>> response = new();
            try 
            {
                IEnumerable<Command> getAll = await _commandRepository.GetAll();
                IEnumerable<Command> userCommand = getAll.Where(x => x.AuthId == Auth)
                                    .ToList();
                response.Data=_mapper.Map<IEnumerable<CommandDto>>(userCommand);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch(Exception ) 
            {
                response.Data= Enumerable.Empty<CommandDto>();
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CommandDto>>> GetCommandByPiece(int PieceId)
        {
            ServiceResponse<IEnumerable<CommandDto>> response = new();
            try
            {

                response.Data = _mapper.Map<IEnumerable<CommandDto>>(await _commandRepository.GetAllFromPiece(PieceId));
                response.Success = true;
                response.Message ="opération Réussi";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                response.Data=new List<CommandDto>();
                response.Success = false;
                response.Message = "opération Réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            return response;
        }

        public async Task<ServiceResponse<CommandDto>> UpdateCommand(int id,UpdateCommandDto command)
        {
            ServiceResponse<CommandDto> response = new ServiceResponse<CommandDto>();
            try
            {
                var entityToUpdate= _mapper.Map<Command>(command);
                await _commandRepository.Update(id, entityToUpdate);

                response.Success = true;
                response.Message = "mise a jour réussis";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                _logger.LogInformation("Verified Command");
                response.Success = false;
                response.Message = "Une Erreur a eu lieu lors de la mise a jour";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> VerifiedCommand(int pieceId, string userId)
        {
            ServiceResponse<bool> response= new ServiceResponse<bool>();
            try
            {
                response.Data= await _commandRepository.DoIHaveACommandForPiece(pieceId, userId);
                response.Success=true;
                response.Message = "commande vérifier";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Verified Command");
                response.Success = false;
                response.Message = $"une erreur a eu lieur : message : {ex.Message}";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> CommandExist(int commandId)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                await _commandRepository.DoYouExist(commandId);
                response.Success = true;
                response.Message = "opération réussi la commande Existe";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Existed command");
                response.Success = false;
                response.Message = $"une erreur a eu lieur : message : {ex.Message}";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
