using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Models;

namespace Schedule.Data.Repositories
{
    public class ProviderDocumentRepository : Repository<ProviderDocument>, IProviderDocumentRepository
    {
        public ProviderDocumentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
