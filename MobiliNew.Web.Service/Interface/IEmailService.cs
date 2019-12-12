using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Repository.Interfaces;
using MobiliNew.Web.service.Interface;
using MobiliNew.Web.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiliNew.Web.Service.Interface
{
    public interface IEmailService : IService<EmailQueue>
    {
        void AddMailToQueue(EmailQueue emailData);
    }
}