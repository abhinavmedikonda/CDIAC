using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CDIAC.Common.Models.MailService;
using CDIAC.Common.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CDIAC.Common.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<MailResponse> SendEmailAsync(MailRequest mailRequest)
        {
            MailResponse mailResponse = new MailResponse();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            if (mailRequest.ToEmail != null)
            {
                email.To.AddRange(ParseMailboxAddress(mailRequest.ToEmail));
            }

            if (mailRequest.CcEmail != null)
            {
                email.Cc.AddRange(ParseMailboxAddress(mailRequest.CcEmail));
            }

            if (mailRequest.BccEmail != null)
            {
                email.Bcc.AddRange(ParseMailboxAddress(mailRequest.BccEmail));
            }

            if (email.To.Count == 0 && email.Cc.Count == 0 && email.Bcc.Count == 0)
            {
                mailResponse.Errors.Add("No recipients to send mail.");
                return mailResponse;
            }

            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            return await SendRetry(email, 3, mailResponse);
        }

        private List<MailboxAddress> ParseMailboxAddress(List<string> emailList)
        {
            List<MailboxAddress> parsedList = new List<MailboxAddress>();
            foreach (var item in emailList)
            {
                if (item == null)
                {
                    continue;
                }

                MailboxAddress parsedEmail;
                if (MailboxAddress.TryParse(item, out parsedEmail))
                {
                    parsedList.Add(parsedEmail);
                }
            }

            return parsedList;
        }

        private async Task<MailResponse> SendRetry(MimeMessage mimeMessage, int retries, MailResponse mailResponse)
        {
            try
            {
                using var smtpClient = new SmtpClient();
                smtpClient.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtpClient.SendAsync(mimeMessage);
                smtpClient.Disconnect(true);
                return mailResponse;
            }
            catch (Exception ex)
            {
                if (--retries == 0)
                {
                    mailResponse.Errors.Add(ex.Message);
                    return mailResponse;
                }
                else
                {
                    mailResponse.Errors.Add(ex.Message);
                    await Task.Delay(5000);
                    await SendRetry(mimeMessage, retries, mailResponse);
                }

                return mailResponse;
            }
        }
    }
}
