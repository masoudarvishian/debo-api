using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DEBO.Core.Entity;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
        where T : BaseEntity<TKey>
        where TInputDto : class
        where TOutputDto : class
        where TUpdateDto : class
    {
        IEnumerable<TOutputDto> GetAll();
        IEnumerable<TOutputDto> GetAll(Expression<Func<T, bool>> expression);
        TOutputDto GetOne(Expression<Func<T, bool>> expression);
        Task<T> InsertAsync(TInputDto entityInsertDto);
        Task<T> UpdateAsync(TKey id, TUpdateDto entityUpdateDto);
        Task DeleteAsync(TKey id);
    }
}