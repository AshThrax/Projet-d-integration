using ApplicationTheather.DTO;

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
        Task<List<TicketDto>> GenerateCommandTicket(int CommandeId);
        /// <summary>
        /// ajout une nouvelle commmande a la base de donnée
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task AddCommand(AddCommandDto command);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Auth"></param>
        /// <returns></returns>
        Task<IEnumerable<CommandDto>> GetCommandUSer(string Auth);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommandDto>> GetAllCommand();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CommandDto> GetCommand(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteCommand(int id);
    }
}
