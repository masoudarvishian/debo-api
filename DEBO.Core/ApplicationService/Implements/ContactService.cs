using System;
using System.Collections.Generic;
using System.Linq;
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

        public Contact Insert(ContactDto contactDto)
        {
            var contact = new Contact
            {
                Id = contactDto.Id,
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                PhoneNumber = contactDto.PhoneNumber,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            _unitOfWork.ContactRepository.Create(contact);
            _unitOfWork.SaveChanges();

            return contact;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            List<ContactDto> contactDtos = new List<ContactDto>();

            var allContacts = _unitOfWork.ContactRepository.FindAll();

            var mappedContatDtos = from x in allContacts
                                   select new ContactDto
                                   {
                                       Id = x.Id,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       PhoneNumber = x.PhoneNumber
                                   };

            contactDtos = mappedContatDtos.ToList();

            return contactDtos;
        }

        public Contact Update(ContactDto contactDto)
        {
            var foundContact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == contactDto.Id).SingleOrDefault();

            if (foundContact == null)
            {
                return null;
            }

            foundContact.FirstName = contactDto.FirstName;
            foundContact.LastName = contactDto.LastName;
            foundContact.PhoneNumber = contactDto.PhoneNumber;
            foundContact.ModifyDate = DateTime.Now;

            _unitOfWork.ContactRepository.Update(foundContact);
            _unitOfWork.SaveChanges();

            return foundContact;
        }

        public ContactDto GetById(int id)
        {
            var contact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == id).SingleOrDefault();

            if (contact == null) return null;

            ContactDto contactDto = new ContactDto();

            contactDto.Id = contact.Id;
            contactDto.FirstName = contact.FirstName;
            contactDto.LastName = contactDto.LastName;
            contactDto.PhoneNumber = contactDto.PhoneNumber;

            return contactDto;
        }

        public void Delete(int id)
        {
            var contact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == id).SingleOrDefault();

            if (contact == null) throw new Exception("Contact not found!");

            contact.IsDelete = true;
            contact.ModifyDate = DateTime.Now;

            _unitOfWork.ContactRepository.Update(contact);
            _unitOfWork.SaveChanges();
        }
    }
}
