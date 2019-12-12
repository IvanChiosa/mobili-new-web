using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Repository.Interfaces;
using MobiliNew.Web.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiliNew.Web.Service.Implementation
{
    public class EmailService : Service<EmailQueue>, IEmailService
    {
        private readonly IRepository<EmailQueue> _repository;

        public EmailService(IRepository<EmailQueue> repository) : base(repository)
        {
            _repository = repository;
        }

        public void AddMailToQueue(EmailQueue emailData)
        {
            _repository.Insert(emailData);
        }
    }
}

