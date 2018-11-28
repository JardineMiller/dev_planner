using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace dev_planner_backend.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> logger;

        private readonly string mailTo = Startup.Config["mailSettings:mailTo"];
        private readonly string mailFrom = Startup.Config["mailSettings:mailFrom"];
        
        public LocalMailService(ILogger<LocalMailService> logger)
        {
            this.logger = logger;
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