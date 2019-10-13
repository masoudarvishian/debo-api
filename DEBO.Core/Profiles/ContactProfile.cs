namespace DEBO.Core.Profiles
{
    using Entity.Contact.Dtos;
    using DEBO.Core.Entity.Contact;

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
