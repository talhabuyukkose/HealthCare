using HealthCare.Core.Cqrs.Queries.Appointments;
using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Quartz
{
    public class SendEmailOrSmsJob : IJob
    {
        private readonly ILogger<SendEmailOrSmsJob> logger;
        private readonly IMediator mediator;

        public SendEmailOrSmsJob(ILogger<SendEmailOrSmsJob> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var query = new GetAppointmentIncludedFilterQuery()
            {
                dateTime = DateTime.Now,
            };

            var response = await mediator.Send(query);

            foreach (var item in response)
            {
                if (item.Patient.IsSendEmail)
                {
                    SendEmail(item.Patient.Email);
                }
                else if(item.Patient.IsSendSms)
                {
                    SendSms(item.Patient.Mobile);
                }
                else
                {
                    logger.LogInformation($"{item.Patient.FirstName} {item.Patient.LastName} hastası hatırlatma seçeneği kullanmıyor.");
                }
            }

        }

        void SendEmail(string email)
        {
            logger.LogInformation($"{email} adresine mail gönderiliyor...");
        }
        void SendSms(string phoneNumber)
        {
            logger.LogInformation($"{phoneNumber} numaralı telefona SMS gönderiliyor...");
        }
    }
}
