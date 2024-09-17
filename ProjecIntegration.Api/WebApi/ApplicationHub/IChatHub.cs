namespace WebApi.ApplicationHub
{
    public interface IChatHub
    {
        Task SendMessage(string message);
    }
}
