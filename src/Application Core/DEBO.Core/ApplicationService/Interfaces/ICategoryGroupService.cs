using DEBO.Core.Entity.CategoryGroup;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface ICategoryGroupService : IBaseService<CategoryGroup, int,
        CategoryGroupInputDto, CategoryGroupOutputDto, CategoryGroupUpdateDto>
    {
    }
}