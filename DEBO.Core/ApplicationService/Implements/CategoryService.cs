using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Implements
{
    public class CategoryService :
        BaseService<Category, int, CategoryInsertDto, CategoryOutputDto,
            CategoryUpdateDto>, ICategoryService
    {
        private readonly IUnitOfWork<Category> _unitOfWork;
        private readonly IDataMapper _dataMapper;

        public CategoryService(IUnitOfWork<Category> unitOfWork,
            IDataMapper dataMapper) : base(unitOfWork, dataMapper)
        {
            _unitOfWork = unitOfWork;
            _dataMapper = dataMapper;
        }
    }
}