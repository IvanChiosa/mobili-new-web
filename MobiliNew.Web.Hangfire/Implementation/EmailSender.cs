using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Repository.Interfaces;
using MobiliNew.Web.Service.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MobiliNew.Web.Hangfire.Implementation
{
    public class EmailSender : Service<EmailQueue>, IEmailSender
    {
        private readonly IRepository<EmailQueue> _repository;
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _iconfiguration;

        public EmailSender(IRepository<EmailQueue> repository, IHostingEnvironment environment, IConfiguration iconfiguration) : base(repository)
        {
            _repository = repository;
            _environment = environment;
            _iconfiguration = iconfiguration;
        }

        public List<EmailQueue> GetEmailToSendWithUser() //method to ?
        {
            return _repository.QueryableIncluding()
                                      .Where(q => q.AttemptsRemaining > 0
                                                    && !q.IsSent)
                                      .OrderBy(q => q.DateLoading)
                                      .ThenBy(q => q.AttemptsRemaining)
                                      .ToList();
        }

        private string PopulateBody(EmailQueue data)
        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader(Path.Combine(_environment.ContentRootPath, @"here put the path of the html created in the 5.1) session ")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Name}", data.Name);
            body = body.Replace("{Surname}", data.Surname);
            body = body.Replace("{Message}", data.MailBody);
            body = body.Replace("{Date}", data.DateLoading.ToString());
            //body = body.Replace("{PromotionCode}", data.PromotionCode);

            return body;
        }

        public async Task SenderAsync()
        {
            SmtpClient smtpServer = new SmtpClient();

            var mailDatas = GetEmailToSendWithUser();
            foreach (var item in mailDatas)
            {
                item.AttemptsRemaining = item.AttemptsRemaining - 1;
                _repository.Update(item);

                if (item.AttemptsRemaining > 0)
                {
                    MailMessage mail = new MailMessage()
                    {
                        From = new MailAddress(item.FromAddress),
                        Body = PopulateBody(item),
                        IsBodyHtml = true
                    };

                    mail.To.Add(item.ToAddress);

                    if (!string.IsNullOrEmpty(item.BccAddress))
                    {
                        var splittedMails = item.BccAddress.Split(",").ToList();
                        foreach (var email in splittedMails)
                        {
                            mail.Bcc.Add(email);
                        }
                    }

                    mail.Subject = item.MailObject;
                    smtpServer.EnableSsl = false;
                    smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpServer.UseDefaultCredentials = false;

                    smtpServer.Host = _iconfiguration.GetSection("Smtp").GetSection("Host").Value;
                    smtpServer.Port = int.Parse(_iconfiguration.GetSection("Smtp").GetSection("Port").Value);

                    await smtpServer.SendMailAsync(mail);

                    item.IsSent = true;
                    item.DateProcessed = DateTime.Now;
                    item.Status = "Correctly Sent";
                    _repository.Update(item);
                }
                else
                {
                    item.DateProcessed = DateTime.Now;
                    item.Status = "Unable to send E-Mail";
                    _repository.Update(item);
                }
            }
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
