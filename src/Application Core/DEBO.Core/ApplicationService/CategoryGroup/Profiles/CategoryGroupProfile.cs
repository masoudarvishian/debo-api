using AutoMapper;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Core.ApplicationService.CategoryGroup.Profiles
{
    public class CategoryGroupProfile : Profile
    {
        public CategoryGroupProfile()
        {
            CreateMap<Entity.CategoryGroup.CategoryGroup, CategoryGroupOutputDto>();
            CreateMap<CategoryGroupInputDto, Entity.CategoryGroup.CategoryGroup>();
            CreateMap<CategoryGroupUpdateDto, Entity.CategoryGroup.CategoryGroup>();
        }
    }
}
