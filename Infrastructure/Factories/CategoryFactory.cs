using Infrastructure.Dtos;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryDto Create(CategoryEntity categoryEntity)
    {
        try
        {
            return new CategoryDto
            {
                CategoryId = categoryEntity.CategoryId,
                CategoryName = categoryEntity.CategoryName,
            };
        }
        catch { }
        return null!;
    }


    public static IEnumerable<CategoryDto> Create(List<CategoryEntity> categoryEntities)
    {
        List<CategoryDto> categories = [];

        try
        {
            foreach (var categoryEntity in categoryEntities)
                categories.Add(Create(categoryEntity));
        }
        catch { }
        return categories;
    }
}
