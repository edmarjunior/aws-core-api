using Schedule.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Services
{
    public interface IProviderService
    {
        Task<Provider> Add(Provider model);
        Task<IEnumerable<Provider>> Get(string name);
        Task<Model> GetById(int id);
        Task Remove(int id);
        Task Update(Provider provider);
    }
}
