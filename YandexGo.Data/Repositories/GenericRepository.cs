using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Data.Context;
using YandexGo.Data.IRepositories;
using YandexGo.Domain.Commons;

namespace YandexGo.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        public YandexGoDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public GenericRepository()
        {
            dbContext = new YandexGoDbContext();
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
            => (await dbSet.AddAsync(entity)).Entity;


        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
            => expression is null ? dbSet : dbSet.Where(expression);


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => await dbSet.FirstOrDefaultAsync(expression);


        public T Update(T entity)
            => dbSet.Update(entity).Entity;


        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            if (entity is null)
                return false;
            dbSet.Remove(entity);
            return true;
        }

        public async Task SaveAsync() =>
            await dbContext.SaveChangesAsync();
    }
}
