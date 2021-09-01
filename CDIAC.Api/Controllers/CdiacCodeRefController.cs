using System.Collections.Generic;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;
using CDIAC.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDIAC.Api.Controllers
{
    [Route("api/[controller]")]
    public class CdiacCodeRefController : Controller
    {
        private readonly ICdiacCodeRefRepository cdiacCodeRefRepository;
        public CdiacCodeRefController(ICdiacCodeRefRepository cdiacCodeRefRepository)
        {
            this.cdiacCodeRefRepository = cdiacCodeRefRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CdiacCodeRef>> Get()
        {
            try
            {
                return await cdiacCodeRefRepository.Get();
            }
            catch
            {
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{code}")]
        public async Task<CdiacCodeRef> Get(string code)
        {
            try
            {
                return await cdiacCodeRefRepository.Get(code);
            }
            catch
            {
                throw;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] CdiacCodeRef cdiacCodeRef)
        {
            try
            {
                await cdiacCodeRefRepository.Post(cdiacCodeRef);
            }
            catch
            {
                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{code}")]
        public async Task Put(string code, [FromBody] CdiacCodeRef cdiacCodeRef)
        {
            try
            {
                await cdiacCodeRefRepository.Put(code, cdiacCodeRef);
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            try
            {
                await cdiacCodeRefRepository.Delete(code);
            }
            catch
            {
                throw;
            }
        }
    }
}
