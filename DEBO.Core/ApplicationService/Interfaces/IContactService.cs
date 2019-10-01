using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactOutputDto> GetAll();
        ContactOutputDto GetById(int id);
        Task<Contact> InsertAsync(ContactInsertDto contactDto);
        Task<Contact> UpdateAsync(ContactUpdateDto contactDto);
        Task DeleteAsync(int id);
    }
}
