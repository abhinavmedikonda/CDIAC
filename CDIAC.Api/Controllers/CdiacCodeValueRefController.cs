using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;
using CDIAC.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDIAC.Api.Controllers
{
    [Route("api/[controller]")]
    public class CdiacCodeValueRefController : Controller
    {
        private readonly ICdiacCodeValueRefRepository cdiacCodeValueRefRepository;
        public CdiacCodeValueRefController(ICdiacCodeValueRefRepository cdiacCodeValueRefRepository)
        {
            this.cdiacCodeValueRefRepository = cdiacCodeValueRefRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CdiacCodeValueRef>> Get()
        {
            try
            {
                return await cdiacCodeValueRefRepository.Get();
            }
            catch
            {
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CdiacCodeValueRef> Get(long id)
        {
            try
            {
                return await cdiacCodeValueRefRepository.Get(id);
            }
            catch
            {
                throw;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] CdiacCodeValueRef cdiacCodeRef)
        {
            try
            {
                await cdiacCodeValueRefRepository.Post(cdiacCodeRef);
            }
            catch
            {
                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody] CdiacCodeValueRef cdiacCodeRef)
        {
            try
            {
                await cdiacCodeValueRefRepository.Put(id, cdiacCodeRef);
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            try
            {
                await cdiacCodeValueRefRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
