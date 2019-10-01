using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.CustomExceptions;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;

namespace DEBO.Core.ApplicationService.Implements
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contact> InsertAsync(ContactInsertDto contactDto)
        {
            var contact = new Contact
            {
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                PhoneNumber = contactDto.PhoneNumber,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            _unitOfWork.ContactRepository.Create(contact);
            await _unitOfWork.SaveChangesAsync();

            return contact;
        }

        public IEnumerable<ContactOutputDto> GetAll()
        {
            List<ContactOutputDto> contactDtos = new List<ContactOutputDto>();

            var allContacts = _unitOfWork.ContactRepository.FindByCondition(x => !x.IsDelete);

            var mappedContatDtos = from x in allContacts
                                   select new ContactOutputDto
                                   {
                                       Id = x.Id,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       PhoneNumber = x.PhoneNumber
                                   };

            contactDtos = mappedContatDtos.ToList();

            return contactDtos;
        }

        public async Task<Contact> UpdateAsync(ContactUpdateDto contactDto)
        {
            var foundContact = _unitOfWork
                .ContactRepository
                .FindByCondition(x => !x.IsDelete && x.Id == contactDto.Id)
                .SingleOrDefault();

            if (foundContact == null)
            {
                throw new EntityNotFoundException();
            }

            foundContact.FirstName = contactDto.FirstName;
            foundContact.LastName = contactDto.LastName;
            foundContact.PhoneNumber = contactDto.PhoneNumber;
            foundContact.ModifyDate = DateTime.Now;

            _unitOfWork.ContactRepository.Update(foundContact);
            await _unitOfWork.SaveChangesAsync();

            return foundContact;
        }

        public ContactOutputDto GetById(int id)
        {
            var contact = _unitOfWork
                .ContactRepository
                .FindByCondition(x => !x.IsDelete && x.Id == id)
                .SingleOrDefault();

            if (contact == null)
            {
                throw new EntityNotFoundException();
            }

            ContactOutputDto contactDto = new ContactOutputDto();

            contactDto.Id = contact.Id;
            contactDto.FirstName = contact.FirstName;
            contactDto.LastName = contact.LastName;
            contactDto.PhoneNumber = contact.PhoneNumber;

            return contactDto;
        }

        public async Task DeleteAsync(int id)
        {
            var contact = _unitOfWork
                .ContactRepository
                .FindByCondition(x => !x.IsDelete && x.Id == id)
                .SingleOrDefault();

            if (contact == null)
            {
                throw new EntityNotFoundException();
            }

            contact.IsDelete = true;
            contact.ModifyDate = DateTime.Now;

            _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
