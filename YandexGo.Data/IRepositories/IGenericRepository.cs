using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace YandexGo.Data.IRepositories
{
    public interface IGenericRepository<T>
    {
        T Update(T entity);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        Task<T> CreateAsync(T entity);
        Task SaveAsync();
    }
}
