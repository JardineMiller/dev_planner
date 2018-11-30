namespace dev_planner_backend.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}