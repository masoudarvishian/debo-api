using DEBO.Core.Entity;
using DEBO.Core.Entity.Contact;
using System.Collections.Generic;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetAll();
        ContactDto GetById(int id);
        Contact Insert(ContactDto contactDto);
        Contact Update(ContactDto contactDto);
        void Delete(int id);
    }
}
