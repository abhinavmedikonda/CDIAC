using System.Threading.Tasks;
using CDIAC.Common.Models.MailService;

namespace CDIAC.Common.Services.Interfaces
{
    public interface IMailService
    {
        Task<MailResponse> SendEmailAsync(MailRequest mailRequest);
    }
}
