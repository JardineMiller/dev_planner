using dev_planner_backend.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using ILogger = NLog.ILogger;

namespace dev_planner_backend.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> logger;

        private readonly string mailTo;
        private readonly string mailFrom;
        
        public LocalMailService(ILogger<LocalMailService> logger, IOptions<MailSettings> mailSettings)
        {
            this.logger = logger;
            this.mailTo = mailSettings.Value.MailTo;
            this.mailFrom = mailSettings.Value.MailTo;
        }
        
        public void Send(string subject, string message) 
        {
            // send mail - output to debug window/log file
            logger.LogInformation($"Mail from {mailFrom} to {mailTo}, with LocalMailService");
            logger.LogInformation($"Subject: {subject}");
            logger.LogInformation($"Message: {message}");

        }
    }
}