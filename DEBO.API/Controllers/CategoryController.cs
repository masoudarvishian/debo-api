using DEBO.API.Models;
using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;
using DEBO.Core.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route(ApiConstans.BaseRoute)]
    [ApiController]
    public class CategoryController : BaseRestApiController<Category, int,
        CategoryInputDto, CategoryOutputDto, CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            IBaseService<Category, int,
                    CategoryInputDto, CategoryOutputDto, CategoryUpdateDto>
                baseService,
            ICategoryService categoryService) : base(baseService)
        {
            _categoryService = categoryService;
        }
    }
}