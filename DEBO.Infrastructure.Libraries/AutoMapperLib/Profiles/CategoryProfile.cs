using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Infrastructure.Libraries.AutoMapperLib.Profiles
{
    public class CategoryProfile : AutoMapper.Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryOutputDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryInsertDto, Category>();
        }
    }
}
