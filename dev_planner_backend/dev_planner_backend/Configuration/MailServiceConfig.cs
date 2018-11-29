using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_planner_backend.Configuration
{
    public class MailServiceConfig
    {
        public MailSettings MailSettings { get; set; }
    }

    public class MailSettings
    {
        public string MailTo { get; set; }
        public string MailFrom { get; set; }
    }
}
