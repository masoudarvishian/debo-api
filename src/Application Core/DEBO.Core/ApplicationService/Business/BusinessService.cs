using AutoMapper;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Business.Dtos;

namespace DEBO.Core.ApplicationService.Business
{
    public class BusinessService : BaseService<
        Entity.Business.Business,
            int,
            BusinessInputDto,
            BusinessOutputDto,
            BusinessUpdateDto>, IBusinessService
    {
        public BusinessService(IUnitOfWork unitOfWork, IMapper dataMapper)
            : base(unitOfWork, dataMapper)
        {
        }
    }
}
