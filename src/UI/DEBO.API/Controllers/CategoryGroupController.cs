using DEBO.API.Models;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.ApplicationService.CategoryGroup;
using DEBO.Core.Entity.CategoryGroup;
using DEBO.Core.Entity.CategoryGroup.Dtos;
using DEBO.Core.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route(ApiConstans.BaseRoute)]
    [ApiController]
    public class CategoryGroupController : BaseRestApiController<CategoryGroup,
        int, CategoryGroupInputDto, CategoryGroupOutputDto,
        CategoryGroupUpdateDto>
    {
        private readonly ICategoryGroupService _categoryGroupService;

        public CategoryGroupController(IBaseService<CategoryGroup,
            int, CategoryGroupInputDto, CategoryGroupOutputDto,
            CategoryGroupUpdateDto> baseService,
            ICategoryGroupService categoryGroupService) : base(baseService)
        {
            _categoryGroupService = categoryGroupService;
        }
    }
}