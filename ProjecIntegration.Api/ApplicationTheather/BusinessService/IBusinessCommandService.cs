using WebApi.Application.DTO;

namespace ApplicationTheather.BusinessService
{
    public interface IBusinessCommandService
    {
        /// <summary>
        ///  construit les ticket lié a une commande 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Auth"></param>
        /// <returns></returns>
        Task GenerateCommandTicket(AddCommandDto command, string Auth);
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
