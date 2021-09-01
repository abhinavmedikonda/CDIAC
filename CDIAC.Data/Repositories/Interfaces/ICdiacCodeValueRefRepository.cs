using System.Collections.Generic;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;

namespace CDIAC.Data.Repositories.Interfaces
{
    public interface ICdiacCodeValueRefRepository
    {
        Task<IEnumerable<CdiacCodeValueRef>> Get();

        Task<CdiacCodeValueRef> Get(long id);

        Task Post(CdiacCodeValueRef CdiacCodeValueRef);

        Task Put(long id, CdiacCodeValueRef CdiacCodeValueRef);

        Task Delete(long id);
    }
}
