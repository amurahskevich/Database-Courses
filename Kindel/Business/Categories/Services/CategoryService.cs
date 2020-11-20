using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Categories.Mapping;
using Contracts.Category;
using Domain;

namespace Business.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork unitOfWork;

        public CategoryService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<IReadOnlyCollection<CategoryDto>> GetList()
        {
            var categories = await this.unitOfWork.CategoryRepository.GetList();

            return categories.Select(CategoryMapper.Map).ToArray();
        }

        public async Task<CategoryDto> Get(int id)
        {
            var category = await this.unitOfWork.CategoryRepository.Get(id);

            return CategoryMapper.Map(category);
        }

        public async Task Create(CategoryDto category)
        {
            var result = CategoryMapper.MapCreate(category);

            await this.unitOfWork.CategoryRepository.Create(result);
        }

        public async Task Update(CategoryDto category)
        {
            var result = await this.unitOfWork.CategoryRepository.Get(category.Id);
            CategoryMapper.MapUpdate(result, category);

            await this.unitOfWork.CategoryRepository.Update(result);
        }

        public async Task Delete(int id)
        {
            var category = await this.unitOfWork.CategoryRepository.Get(id);

            await this.unitOfWork.CategoryRepository.Delete(category);
        }
    }
}
