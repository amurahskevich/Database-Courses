using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Category;

namespace Business.Categories.Services
{
    public interface ICategoryService
    {
        Task<IReadOnlyCollection<CategoryDto>> GetList();

        Task<CategoryDto> Get(int id);

        Task Create(CategoryDto category);

        Task Update(CategoryDto category);

        Task Delete(int id);
    }
}
