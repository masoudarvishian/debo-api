using DEBO.API.Models;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.Entity.Constants;
using DEBO.Core.Entity.Item;
using DEBO.Core.Entity.Item.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route(ApiConstans.BaseRoute)]
    [ApiController]
    public class ItemController 
        : BaseRestApiController<Item, int, ItemInputDto, ItemOutputDto, ItemUpdateDto>
    {
        public ItemController(IBaseService<Item, int, ItemInputDto, ItemOutputDto, ItemUpdateDto> baseService) 
            : base(baseService)
        {
        }
    }
}