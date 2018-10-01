using System;

namespace ProjectMonitor.Models
{
    public class UserLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Page { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string IpAdress { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
    }
}