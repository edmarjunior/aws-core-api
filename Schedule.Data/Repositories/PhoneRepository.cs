using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Models;

namespace Schedule.Data.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
