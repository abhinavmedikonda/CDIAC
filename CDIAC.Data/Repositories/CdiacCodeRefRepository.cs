using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;
using CDIAC.Data.Repositories.Interfaces;

namespace CDIAC.Data.Repositories
{
    public class CdiacCodeRefRepository : ICdiacCodeRefRepository
    {
        private List<CdiacCodeRef> cdiacCodeRefs;
        public CdiacCodeRefRepository()
        {
            cdiacCodeRefs = new List<CdiacCodeRef>
            {
                new CdiacCodeRef{ CdiacCode = "ab", CdiacCodeDesc = "abcd" },
                new CdiacCodeRef{ CdiacCode = "ef", CdiacCodeDesc = "efgh" },
                new CdiacCodeRef{ CdiacCode = "mn", CdiacCodeDesc = "mnop" },
                new CdiacCodeRef{ CdiacCode = "st", CdiacCodeDesc = "stuv" },
            };
        }

        public async Task<IEnumerable<CdiacCodeRef>> Get()
        {
            return await Task.Run(() => cdiacCodeRefs);
        }

        public async Task<CdiacCodeRef> Get(string code)
        {
            var row = cdiacCodeRefs.Where(x => x.CdiacCode.Equals(code)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            return await Task.Run(() => row);
        }

        public async Task Post(CdiacCodeRef cdiacCodeRef)
        {
            await Task.Run(() => cdiacCodeRefs.Add(cdiacCodeRef));
        }

        public async Task Put(string code, CdiacCodeRef cdiacCodeRef)
        {
            var row = cdiacCodeRefs.Where(x => x.CdiacCode.Equals(code)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            await Task.Run(() => {
                row.CdiacCode = cdiacCodeRef.CdiacCode;
                row.CdiacCodeDesc = cdiacCodeRef.CdiacCodeDesc;
            });
        }

        public async Task Delete(string code)
        {
            var row = cdiacCodeRefs.Where(x => x.CdiacCode.Equals(code)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            await Task.Run(() => {
                cdiacCodeRefs.Remove(row);
            });
        }
    }
}
