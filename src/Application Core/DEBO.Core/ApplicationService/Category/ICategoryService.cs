using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Category
{
    public interface ICategoryService : IBaseService<Entity.Category.Category, int,
        CategoryInputDto, CategoryOutputDto,
        CategoryUpdateDto>
    {
    }
}