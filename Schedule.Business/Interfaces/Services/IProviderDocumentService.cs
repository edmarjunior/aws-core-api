using Schedule.Business.Models;
using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Services
{
    public interface IProviderDocumentService
    {
        Task<ProviderDocument> Add(ProviderDocument document);
        Task Remove(int id);
    }
}
