using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IBaseService<T, TKey, TInsertDto, TOutputDto, TUpdateDto>
    {
        IEnumerable<TOutputDto> GetAll();
        TOutputDto GetById(TKey id);
        Task<T> InsertAsync(TInsertDto entityInsertDto);
        Task<T> UpdateAsync(TUpdateDto entityUpdateDto);
        Task DeleteAsync(TKey id);
    }
}
