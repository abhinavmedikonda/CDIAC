using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDIAC.Common.Models.Application;
using CDIAC.Common.Models.MailService;
using CDIAC.Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDIAC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<BaseResponse> Send([FromForm] MailRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var mailResponse = await mailService.SendEmailAsync(request);
                baseResponse.Errors = mailResponse.Errors;

                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Errors.Add(ex.Message);
                return baseResponse;
            }
        }
    }
}
