namespace dev_planner_backend.Services.Mail
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}