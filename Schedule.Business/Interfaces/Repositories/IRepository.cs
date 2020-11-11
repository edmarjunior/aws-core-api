using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Schedule.Business.Interfaces.Repositories
{
    public interface IRepository<Model> 
    {
        Task<IEnumerable<Model>> GetAll();
        Task<IEnumerable<Model>> Get(Expression<Func<Model, bool>> predicate);
        Task<Model> GetById(int id, bool tracking = true);
        Task<Model> Add(Model model);
        Task Update(Model model);
        Task Remove(int id);
        Task Remove(Model model);
        Task Remove(IEnumerable<Model> models);
        Task<IDbContextTransaction> BeginTransaction();
    }
}
