using Contracts.Category;
using Domain.Entity;

namespace Business.Categories.Mapping
{
    public static class CategoryMapper
    {
        public static Category MapCreate(CategoryDto category)
        {
            return new Category
            {
                Name = category.Name,
            };
        }

        public static void MapUpdate(Category oldCategory, CategoryDto newCategory)
        {
            oldCategory.Name = newCategory.Name;
        }

        public static CategoryDto Map(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
