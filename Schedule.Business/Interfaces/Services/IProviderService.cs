using Schedule.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> Get(string name);
        Task Remove(int id);
        Task Update(Provider provider);
    }
}
