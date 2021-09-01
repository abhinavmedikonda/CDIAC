using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDIAC.Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDIAC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : Controller
    {

        private readonly IPdfService pdfService;
        public PdfController(IPdfService pdfService)
        {
            this.pdfService = pdfService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                await pdfService.CreatePdfAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
