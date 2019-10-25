using AutoMapper;
using DEBO.Core.Entity.Business.Dtos;

namespace DEBO.Core.ApplicationService.Business.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Entity.Business.Business, BusinessOutputDto>();
            CreateMap<BusinessInputDto, Entity.Business.Business>();
            CreateMap<BusinessUpdateDto, Entity.Business.Business>();
        }
    }
}
