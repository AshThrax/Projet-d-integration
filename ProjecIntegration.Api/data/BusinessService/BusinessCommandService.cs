
using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using DataInfraTheather.Services;
using Domain.Entity.TheatherEntity;

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
        private readonly IMapper _mapper;

        public BusinessCommandService(
            ICommandRepository commandRepository,
            IPieceRepository pieceRepository,
            ISalleDeTheatreRepository sallerepository,
            IMapper mapper,
            IRepresentationRepository representationRepository,
            ISiegeRepository siegeRepository,
            ISiegeCommandRepository siegeCommandRepository
            )
        {
            _mapper = mapper;
            _sallerepository = sallerepository;
            _piecerepository = pieceRepository;
            _commandRepository = commandRepository;
            _representationRepository = representationRepository;
            _siegeRepository=siegeRepository;
            _siegeCommandRepository=siegeCommandRepository;
        }

        public async Task DeleteCommand(int id)
        {
            try 
            {
                
                Command getEntity = await _commandRepository.GetById(id);
                if (getEntity != null)
                {
                    await _commandRepository.Delete(id);
                }
            }
            catch (Exception) 
            { 
            }
        }

        public async Task<List<TicketDto>> GenerateCommandTicket(int CommandeId)
        {

            Command command = await  _commandRepository.GetCommand(CommandeId);
            try
            {
                
                Representation representation = await _representationRepository.GetById(command.IdRepresentation);//récuperation de la seance 
                int PieceID = representation.PieceId;    //recuperation de la piece
                var Piece = await _piecerepository.GetById(PieceID);
                var salle = await _sallerepository.GetById(representation.SalledeTheatreId);
                var DateToString = representation.Seance;
                //génération du ticket
                return TicketGenerator.GetTicketUser(command.NombreDePlace, Piece.Titre, salle.Name,representation.Id,DateToString);
            }
            catch (Exception)
            {
                return new List<TicketDto>();
            }
        }

        public async Task AddCommand( AddCommandDto command)
        {
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
                        }
                    }
                    else
                    {
                     //faire un truc
                    }

                } 
            }
            catch(Exception)
            { 

            }
          
        }

        public async Task<IEnumerable<CommandDto>> GetAllCommand()
        {
            try
            { 
                var getAll = await _commandRepository.GetAll();
                return _mapper.Map<IEnumerable<CommandDto>>(getAll);
            }
            catch (Exception )
            {
                return new List<CommandDto>();
            }
           
        }

        public async Task<CommandDto> GetCommand(int id)
        {
            try 
            { 
                    Command getEntity = await _commandRepository.GetById(id);
                    return _mapper.Map<CommandDto>(getEntity);
            }
            catch(Exception )
            {
                return new CommandDto();
            }
           
            
        }

        public async Task<IEnumerable<CommandDto>> GetCommandUSer(string Auth)
        {
            try 
            {
                IEnumerable<Command> getAll = await _commandRepository.GetAll();
                IEnumerable<Command> userCommand = getAll.Where(x => x.AuthId == Auth)
                                    .ToList();
                return _mapper.Map<IEnumerable<CommandDto>>(userCommand);
            }
            catch(Exception ) 
            { 
                return  Enumerable.Empty<CommandDto>();
            }
          

        }

        public async Task<IEnumerable<CommandDto>> GetCommandByPiece(int PieceId)
        {
            try
            {
                return _mapper.Map<IEnumerable<CommandDto>>(await _commandRepository.GetAllFromPiece(PieceId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCommand(int id,UpdateCommandDto command)
        {
            try
            {
                var entityToUpdate= _mapper.Map<Command>(command);
                 _commandRepository.Update(id, entityToUpdate);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
