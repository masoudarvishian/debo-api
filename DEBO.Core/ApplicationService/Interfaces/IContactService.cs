using DEBO.Core.Entity;
using DEBO.Core.Entity.Contact;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IContactService
    {
        void CreateContact(ContactDto contactDto);
    }
}
