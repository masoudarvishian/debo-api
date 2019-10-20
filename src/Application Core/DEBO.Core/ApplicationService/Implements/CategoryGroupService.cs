using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.CategoryGroup;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Core.ApplicationService.Implements
{
    public class CategoryGroupService : BaseService<CategoryGroup, int,
            CategoryGroupInputDto, CategoryGroupOutputDto,
            CategoryGroupUpdateDto>,
        ICategoryGroupService
    {
        public CategoryGroupService(IUnitOfWork<CategoryGroup> unitOfWork,
            IDataMapper dataMapper) : base(unitOfWork,
            dataMapper)
        {
        }
    }
}