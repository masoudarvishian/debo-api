using System.Collections.Generic;
using System.Threading.Tasks;
using DEBO.Core.Entity;

namespace DEBO.Core.ApplicationService.BaseService
{
    public interface IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
        where T : BaseEntity<TKey>
        where TInputDto : class
        where TOutputDto : class
        where TUpdateDto : class
    {
        IEnumerable<TOutputDto> GetAll();
        TOutputDto GetOne(TKey id);
        Task<T> InsertAsync(TInputDto entityInsertDto);
        Task<T> UpdateAsync(TKey id, TUpdateDto entityUpdateDto);
        Task DeleteAsync(TKey id);
    }
}