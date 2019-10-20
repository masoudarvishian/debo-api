using AutoMapper;
using DEBO.Core.Entity.CategoryGroup;
using DEBO.Core.Entity.CategoryGroup.Dtos;

namespace DEBO.Infrastructure.Libraries.AutoMapperLib.Profiles
{
    public class CategoryGroupProfile : Profile
    {
        public CategoryGroupProfile()
        {
            CreateMap<CategoryGroup, CategoryGroupOutputDto>();
            CreateMap<CategoryGroupInputDto, CategoryGroup>();
            CreateMap<CategoryGroupUpdateDto, CategoryGroup>();
        }
    }
}
