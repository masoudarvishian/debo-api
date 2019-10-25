using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.Entity.Business.Dtos;

namespace DEBO.Core.ApplicationService.Business
{
    public interface IBusinessService : 
        IBaseService<
            Entity.Business.Business, 
            int, 
            BusinessInputDto, 
            BusinessOutputDto, 
            BusinessUpdateDto>
    {
    }
}
