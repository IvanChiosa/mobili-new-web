using System;
using System.Collections.Generic;

namespace MobiliNew.Web.Data.Models
{
    public partial class Contacts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Privacy { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastModification { get; set; }
        public Guid? SerialKey { get; set; }
    }
}
