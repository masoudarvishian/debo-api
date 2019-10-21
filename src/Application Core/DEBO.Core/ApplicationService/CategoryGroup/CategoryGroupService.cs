using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Core.ApplicationService.CategoryGroup
{
    public class CategoryGroupService : BaseService<Entity.CategoryGroup.CategoryGroup, int,
            CategoryGroupInputDto, CategoryGroupOutputDto,
            CategoryGroupUpdateDto>,
        ICategoryGroupService
    {
        public CategoryGroupService(IUnitOfWork<Entity.CategoryGroup.CategoryGroup> unitOfWork,
            IDataMapper dataMapper) : base(unitOfWork,
            dataMapper)
        {
        }
    }
}