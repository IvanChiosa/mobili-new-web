using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobiliNew.Web.Hangfire.Interfaces
{
    public interface IEmailSender
    {
        Task Sender();
    }
}
