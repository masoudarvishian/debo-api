using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Category.Profiles
{
    public class CategoryProfile : AutoMapper.Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entity.Category.Category, CategoryOutputDto>();
            CreateMap<CategoryUpdateDto, Entity.Category.Category>();
            CreateMap<CategoryInputDto, Entity.Category.Category>();
        }
    }
}
