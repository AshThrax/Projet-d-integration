
using data.Infrastructure.Repository;
using dataInfraTheather.Models.Entity;
using dataInfraTheather.Repository.Interfaces.IRepository;
using WebApi.Application.DTO;

namespace WebApi.BusinessService.Command
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

        public async Task GenerateCommandTicket(AddCommandDto command, string auth)
        {
            var representation = await _representationRepository.GetById(command.IdRepresentation);//récuperation de la seance 
            int PieceID = representation.IdPiece;    //recuperation de la piece
            var Piece = await _piecerepository.GetById(PieceID);
            var salle = await _sallerepository.GetById(Piece.IdSalle);
            var DateToString = representation.Seance.ToString();
            //génération du ticket
            CommandDto commandeMade = new CommandDto
            {
                AuthId = auth,
                IdRepresentation = command.IdRepresentation,
                NombreDePlace = command.NombreDePlace,
                Tickets = Enumerable.Range(0, command.NombreDePlace)//génére le nombre de ticket requis
                                    .Select(_ => new TicketDto
                                    {
                                        Titre = Piece.Titre,
                                        SalleName = salle.Name,
                                        Piecetitle = Piece.Titre,
                                        Representation = DateToString
                                    }).ToList()
            };
            //conversion Dto
            var Conversion = _mapper.Map<Command>(commandeMade);
            //appel du controller pour inserer les ticket data base 
            _commandRepository.AddCommand(Conversion);
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
