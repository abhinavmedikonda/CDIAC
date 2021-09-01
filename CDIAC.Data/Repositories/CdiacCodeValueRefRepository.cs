using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;
using CDIAC.Data.Repositories.Interfaces;

namespace CDIAC.Data.Repositories
{
    public class CdiacCodeValueRefRepository : ICdiacCodeValueRefRepository
    {
        private List<CdiacCodeValueRef> cdiacCodeValueRefs;
        public CdiacCodeValueRefRepository()
        {
            cdiacCodeValueRefs = new List<CdiacCodeValueRef>
            {
                new CdiacCodeValueRef{ ActiveInd = "Y", CdiacCode = "ab", CdiacCodeValueCode = "aab", CdiacCodeValueDesc = "abcd", CdiacCodeValueId = 13323, CreateDatetime = new DateTime(), CreateUserId = "test", LastUpdateDatetime = new DateTime(), LastUpdateUserId = "test" },
                new CdiacCodeValueRef{ ActiveInd = "Y", CdiacCode = "ef", CdiacCodeValueCode = "eff", CdiacCodeValueDesc = "efgh", CdiacCodeValueId = 86756634, CreateDatetime = new DateTime(), CreateUserId = "test", LastUpdateDatetime = new DateTime(), LastUpdateUserId = "test" },
                new CdiacCodeValueRef{ ActiveInd = "Y", CdiacCode = "mn", CdiacCodeValueCode = "mmn", CdiacCodeValueDesc = "mnop", CdiacCodeValueId = 367345, CreateDatetime = new DateTime(), CreateUserId = "test", LastUpdateDatetime = new DateTime(), LastUpdateUserId = "test" },
                new CdiacCodeValueRef{ ActiveInd = "Y", CdiacCode = "st", CdiacCodeValueCode = "stt", CdiacCodeValueDesc = "stuv", CdiacCodeValueId = 687875, CreateDatetime = new DateTime(), CreateUserId = "test", LastUpdateDatetime = new DateTime(), LastUpdateUserId = "test" },
            };
        }

        public async Task<IEnumerable<CdiacCodeValueRef>> Get()
        {
            return await Task.Run(() => cdiacCodeValueRefs);
        }

        public async Task<CdiacCodeValueRef> Get(long id)
        {
            var row = cdiacCodeValueRefs.Where(x => x.CdiacCodeValueId.Equals(id)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            return await Task.Run(() => row);
        }

        public async Task Post(CdiacCodeValueRef cdiacCodeValueRef)
        {
            await Task.Run(() => cdiacCodeValueRefs.Add(cdiacCodeValueRef));
        }

        public async Task Put(long id, CdiacCodeValueRef cdiacCodeValueRef)
        {
            var row = cdiacCodeValueRefs.Where(x => x.CdiacCodeValueId.Equals(id)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            await Task.Run(() => {
                row.ActiveInd = cdiacCodeValueRef.ActiveInd;
                row.CdiacCode = cdiacCodeValueRef.CdiacCode;
                row.CdiacCodeValueCode = cdiacCodeValueRef.CdiacCodeValueCode;
                row.CdiacCodeValueDesc = cdiacCodeValueRef.CdiacCodeValueDesc;
                row.CdiacCodeValueId = cdiacCodeValueRef.CdiacCodeValueId;
                row.CreateDatetime = cdiacCodeValueRef.CreateDatetime;
                row.CreateUserId = cdiacCodeValueRef.CreateUserId;
                row.LastUpdateDatetime = cdiacCodeValueRef.LastUpdateDatetime;
                row.LastUpdateUserId = cdiacCodeValueRef.LastUpdateUserId;
            });
        }

        public async Task Delete(long id)
        {
            var row = cdiacCodeValueRefs.Where(x => x.CdiacCodeValueId.Equals(id)).FirstOrDefault();
            if (row == null)
            {
                throw new KeyNotFoundException();
            }

            await Task.Run(() => {
                cdiacCodeValueRefs.Remove(row);
            });
        }
    }
}
