using System.Collections.Generic;
using System.Threading.Tasks;
using CDIAC.Common.Models.Admin;

namespace CDIAC.Data.Repositories.Interfaces
{
    public interface ICdiacCodeRefRepository
    {
        Task<IEnumerable<CdiacCodeRef>> Get();

        Task<CdiacCodeRef> Get(string code);

        Task Post(CdiacCodeRef cdiacCodeRef);

        Task Put(string code, CdiacCodeRef cdiacCodeRef);

        Task Delete(string code);
    }
}
