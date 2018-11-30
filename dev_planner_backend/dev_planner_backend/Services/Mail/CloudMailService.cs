using dev_planner_backend.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace dev_planner_backend.Services
{
    public class CloudMailService : IMailService
    {
        private readonly ILogger<CloudMailService> logger;

        private readonly string mailTo;
        private readonly string mailFrom;
        
        public CloudMailService(ILogger<CloudMailService> logger, MailSettings mailSettings)
        {
            this.logger = logger;
            this.mailTo = mailSettings.MailTo;
            this.mailFrom = mailSettings.MailTo;
        }
        
        public void Send(string subject, string message) 
        {
            // send mail - output to debug window/log file
            logger.LogInformation($"Mail from {mailFrom} to {mailTo}, with CloudMailService");
            logger.LogInformation($"Subject: {subject}");
            logger.LogInformation($"Message: {message}");

        }
    }
}