using DEBO.API.Models;
using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.Entity;
using DEBO.Core.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route(ApiConstans.BaseRoute)]
    [ApiController]
    public class BaseRestApiController<T, TKey, TInputDto, TOutputDto,
        TUpdateDto> : ControllerBase
        where T : BaseEntity<TKey>
        where TInputDto : class
        where TOutputDto : class
        where TUpdateDto : class
    {
        #region Ctor

        private readonly
            IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
            _baseService;

        public BaseRestApiController(
            IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
                baseService)
        {
            _baseService = baseService;
        }

        #endregion

        #region GetAll

        [HttpGet]
        public virtual ActionResult<IEnumerable<TOutputDto>> Get()
        {
            var entityOutputDtos = _baseService.GetAll();

            return Ok(entityOutputDtos);
        }

        #endregion

        #region GetById

        [HttpGet("{id}")]
        public virtual ActionResult<TOutputDto> GetById(TKey id)
        {
            var entityOutputDto = _baseService.GetOne(id);
            return Ok(entityOutputDto);
        }

        #endregion

        #region Post

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post(
            TInputDto entityInsertDto)
        {
            var entity =
                await _baseService.InsertAsync(entityInsertDto);
            return CreatedAtAction(nameof(Post),
                entity);
        }

        #endregion

        #region Put

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Put(
            TKey id, TUpdateDto entityUpdateDto)
        {
            var category =
                await _baseService.UpdateAsync(id,
                    entityUpdateDto);
            return Ok(category);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<object>> Delete(TKey id)
        {
            await _baseService.DeleteAsync(id);

            return NoContent();
        }

        #endregion
    }
}