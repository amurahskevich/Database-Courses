using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Common
{
    public interface IBaseService<T>
    {
        Task<T> Get(int id);

        Task<IReadOnlyCollection<T>> GetList();

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
