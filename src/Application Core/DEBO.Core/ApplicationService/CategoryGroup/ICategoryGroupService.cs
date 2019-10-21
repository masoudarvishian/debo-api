using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Core.ApplicationService.CategoryGroup
{
    public interface ICategoryGroupService : IBaseService<Entity.CategoryGroup.CategoryGroup, int,
        CategoryGroupInputDto, CategoryGroupOutputDto, CategoryGroupUpdateDto>
    {
    }
}