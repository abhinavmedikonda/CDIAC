using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CDIAC.Common.Models.MailService
{
    public class MailRequest
    {
        public List<string> ToEmail { get; set; }
        public List<string> CcEmail { get; set; }
        public List<string> BccEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
