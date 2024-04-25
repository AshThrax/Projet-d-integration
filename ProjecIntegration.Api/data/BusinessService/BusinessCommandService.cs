
using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using AutoMapper;
using DataInfraTheather.Services;
using Domain.Entity.TheatherEntity;
using WebApi.Application.DTO;

namespace DataInfraTheather.BusinessService
{
    public class BusinessCommandService : IBusinessCommandService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IRepresentationRepository _representationRepository;
        private readonly IPieceRepository _piecerepository;
        private readonly ISalleDeTheatreRepository _sallerepository;
        private readonly IMapper _mapper;

        public BusinessCommandService(
            ICommandRepository commandRepository,
            IPieceRepository pieceRepository,
            ISalleDeTheatreRepository sallerepository,
            IMapper mapper,
            IRepresentationRepository representationRepository)
        {
            _mapper = mapper;
            _sallerepository = sallerepository;
            _piecerepository = pieceRepository;
            _commandRepository = commandRepository;
            _representationRepository = representationRepository;
        }

        public async Task DeleteCommand(int id)
        {
            var getEntity = await _commandRepository.GetById(id);
            if (getEntity != null)
            {
                _commandRepository.Delete(id);
            }
        }

        public async Task<List<TicketDto>> GenerateCommandTicket(int CommandeId)
        {
            Command command = await  _commandRepository.GetCommand(CommandeId);

            var representation = await _representationRepository.GetById(command.IdRepresentation);//récuperation de la seance 
            int PieceID = representation.IdPiece;    //recuperation de la piece
            var Piece = await _piecerepository.GetById(PieceID);
            var salle = await _sallerepository.GetById(Piece.IdSalle);
            var DateToString = representation.Seance;
            //génération du ticket
            return TicketGenerator.GetTicketUser(command.NombreDePlace, Piece.Titre, salle.Name, DateToString);
        }

        public async Task AddCommand(AddCommandDto command)
        {
            if (command != null)
            {
                //conversion Dto
                var Conversion = _mapper.Map<Command>(command);
                _commandRepository.AddCommand(Conversion);
                //appel du controller pour inserer les ticket da
            }
        }

        public async Task<IEnumerable<CommandDto>> GetAllCommand()
        {
            var getAll = await _commandRepository.GetAll();
            return _mapper.Map<IEnumerable<CommandDto>>(getAll);
        }

        public async Task<CommandDto> GetCommand(int id)
        {
            var getEntity = await _commandRepository.GetById(id);
            return _mapper.Map<CommandDto>(getEntity);
        }

        public async Task<IEnumerable<CommandDto>> GetCommandUSer(string Auth)
        {
            var getAll = await _commandRepository.GetAll();
            var userCommand = getAll.Where(x => x.AuthId == Auth)
                                    .ToList();

            return _mapper.Map<IEnumerable<CommandDto>>(userCommand);
        }
    }
}
