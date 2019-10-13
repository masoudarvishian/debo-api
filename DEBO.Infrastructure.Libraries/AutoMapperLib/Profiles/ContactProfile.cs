using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;

namespace DEBO.Infrastructure.Libraries.AutoMapperLib.Profiles
{
    public class ContactProfile : AutoMapper.Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactOutputDto>();
            CreateMap<ContactInsertDto, Contact>();
            CreateMap<ContactUpdateDto, Contact>();
        }
    }
}
