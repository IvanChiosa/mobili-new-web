using System;
using System.Collections.Generic;

namespace MobiliNew.Web.Data.Models
{
    public partial class EmailQueue
    {
        public Guid Id { get; set; }
        public DateTime DateLoading { get; set; }
        public DateTime DateProcessed { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string MailObject { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string BccAddress { get; set; }
        public string MailBody { get; set; }
        public bool IsSent { get; set; }
        public string Status { get; set; }
        public int AttemptsRemaining { get; set; }
        public int Template { get; set; }
    }
}
