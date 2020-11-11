using Microsoft.EntityFrameworkCore;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Models;
using System.Threading.Tasks;

namespace Schedule.Data.Repositories
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ApplicationContext db) : base(db)
        {

        }

        public override async Task<Provider> GetById(int id, bool tracking)
        {
            return await DbSet
                .AsNoTracking()
                .Include(x => x.Phones)
                .ThenInclude(x => x.Phone)
                .Include(x => x.Documents)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
