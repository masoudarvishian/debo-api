using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface ICategoryService : IBaseService<Category, int,
        CategoryInputDto, CategoryOutputDto,
        CategoryUpdateDto>
    {
    }
}