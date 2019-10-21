using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Category
{
    public class CategoryService :
        BaseService<Entity.Category.Category, int, CategoryInputDto, CategoryOutputDto,
            CategoryUpdateDto>, ICategoryService
    {
        private readonly IUnitOfWork<Entity.Category.Category> _unitOfWork;
        private readonly IDataMapper _dataMapper;

        public CategoryService(IUnitOfWork<Entity.Category.Category> unitOfWork,
            IDataMapper dataMapper) : base(unitOfWork, dataMapper)
        {
            _unitOfWork = unitOfWork;
            _dataMapper = dataMapper;
        }
    }
}