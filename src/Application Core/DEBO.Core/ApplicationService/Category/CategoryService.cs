using AutoMapper;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Category
{
    public class CategoryService :
        BaseService<Entity.Category.Category, int, CategoryInputDto, CategoryOutputDto,
            CategoryUpdateDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork<Entity.Category.Category> unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}