using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Schedule.Data.Repositories
{
    public abstract class Repository<Model> : IRepository<Model> where Model : Business.Models.Model, new()
    {
        protected readonly ApplicationContext Db;
        protected readonly DbSet<Model> DbSet;

        protected Repository(ApplicationContext db)
        {
            Db = db;
            DbSet = db.Set<Model>();
        }

        public async Task<Model> Add(Model model)
        {
            await DbSet.AddAsync(model);
            await Db.SaveChangesAsync();
            return model;
        }

        public async Task<IDbContextTransaction> BeginTransaction() => await Db.Database.BeginTransactionAsync();

        public async Task<IEnumerable<Model>> Get(Expression<Func<Model, bool>> predicate) => await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<IEnumerable<Model>> GetAll() => await DbSet.AsNoTracking().ToListAsync();

        public virtual async Task<Model> GetById(int id) => await DbSet.FindAsync(id);

        public async Task Remove(int id)
        {
            DbSet.Remove(new Model { Id = id });
            await Db.SaveChangesAsync();
        }

        public async Task Remove(IEnumerable<Model> models)
        {
            DbSet.RemoveRange(models);
            await Db.SaveChangesAsync();
        }

        public async Task Update(Model model)
        {
            DbSet.Update(model);
            await Db.SaveChangesAsync();
        }
    }
}
