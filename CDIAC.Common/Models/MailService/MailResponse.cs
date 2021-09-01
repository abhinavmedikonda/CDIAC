using System.Collections.Generic;

namespace CDIAC.Common.Models.MailService
{
    public class MailResponse
    {
        public MailResponse()
        {
            this.Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
    }
}
