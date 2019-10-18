using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;
using DEBO.Core.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryOutputDto>> Get()
        {
            var categoryOutputDtos = _categoryService.GetAll();

            return Ok(categoryOutputDtos);
        }

        [HttpGet("id")]
        public ActionResult<CategoryOutputDto> GetById(int id)
        {
            var categoryOutputDto = _categoryService.GetOne(id);
            return Ok(categoryOutputDto);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(
            CategoryInsertDto categoryInsertDto)
        {
            var category =
                await _categoryService.InsertAsync(categoryInsertDto);
            return CreatedAtAction(nameof(Post),
                category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Put(
            CategoryUpdateDto categoryUpdateDto)
        {
            var category =
                await _categoryService.UpdateAsync(categoryUpdateDto.Id,
                    categoryUpdateDto);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<object>> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}