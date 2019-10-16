using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;

namespace DEBO.Core.ApplicationService.Interfaces
{
    public interface IContactService : IBaseService<Contact, int,
        ContactInsertDto, ContactOutputDto, ContactUpdateDto>
    {
    }
}