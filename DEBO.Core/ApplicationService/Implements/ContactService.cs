using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Contact;

namespace DEBO.Core.ApplicationService.Implements
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateContact(ContactDto contactDto)
        {
            var contact = new Contact
            {
                Id = contactDto.Id,
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                PhoneNumber = contactDto.PhoneNumber
            };

            using (_unitOfWork)
            {
                _unitOfWork.ContactRepository.Create(contact);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
