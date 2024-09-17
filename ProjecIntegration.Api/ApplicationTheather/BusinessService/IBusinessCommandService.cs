using ApplicationTheather.DTO;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessCommandService
    {
        /// <summary>
        ///  construit les ticket lié a une commande 
        /// </summary>
        /// <param name="CommandeId"></param>
        /// <param name="Auth"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<TicketDto>>> GenerateCommandTicket(int CommandeId);
        /// <summary>
        /// ajout une nouvelle commmande a la base de donnée
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<ServiceResponse<CommandDto>> AddCommand( AddCommandDto command);
        /// <summary>
        /// get Command By User
        /// </summary>
        /// <param name="Auth"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<CommandDto>>> GetCommandUSer(string Auth);
        /// <summary>
        /// get Command byPiece
        /// </summary>
        /// <param name="PieceId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<CommandDto>>> GetCommandByPiece(int PieceId);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<CommandDto>>> GetAllCommand();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<CommandDto>> GetCommand(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<CommandDto>> DeleteCommand(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<ServiceResponse<CommandDto>> UpdateCommand(int id,UpdateCommandDto command);

        Task<ServiceResponse<bool>> VerifiedCommand(int pieceId, string userId);
    }
}
