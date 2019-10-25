using DEBO.API.Models;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.Entity.Business;
using DEBO.Core.Entity.Business.Dtos;
using DEBO.Core.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route(ApiConstans.BaseRoute)]
    [ApiController]
    public class BusinessController
        : BaseRestApiController<
            Business,
            int,
            BusinessInputDto,
            BusinessOutputDto,
            BusinessUpdateDto>
    {
        public BusinessController(
            IBaseService<Business,
                int,
                BusinessInputDto,
                BusinessOutputDto,
                BusinessUpdateDto> baseService)
            : base(baseService)
        {
        }
    }
}