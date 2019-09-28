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

            using (_unitOfWork)
            {
                _unitOfWork.ContactRepository.Create(contact);
                _unitOfWork.SaveChanges();
            }

            return contact;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            List<ContactDto> contactDtos = new List<ContactDto>();
            using (_unitOfWork)
            {
                var allContacts = _unitOfWork.ContactRepository.FindAll();

                var queryMap = from x in allContacts
                               select new ContactDto
                               {
                                   Id = x.Id,
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   PhoneNumber = x.PhoneNumber
                               };

                contactDtos = queryMap.ToList();
            }
            return contactDtos;
        }

        public Contact Update(ContactDto contactDto)
        {
            Contact contact = null;

            using (_unitOfWork)
            {
                var foundContact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == contactDto.Id).SingleOrDefault();

                foundContact.FirstName = contactDto.FirstName;
                foundContact.LastName = contactDto.LastName;
                foundContact.PhoneNumber = contactDto.PhoneNumber;
                foundContact.ModifyDate = DateTime.Now;

                _unitOfWork.ContactRepository.Update(foundContact);
                _unitOfWork.SaveChanges();

                contact = foundContact;
            }

            return contact;
        }

        public ContactDto GetById(int id)
        {
            ContactDto contactDto = new ContactDto();

            using(_unitOfWork)
            {
                var contact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == id).SingleOrDefault();

                if (contact != null)
                {
                    contactDto.Id = contact.Id;
                    contactDto.FirstName = contact.FirstName;
                    contactDto.LastName = contactDto.LastName;
                    contactDto.PhoneNumber = contactDto.PhoneNumber;
                }
                else
                {
                    contactDto = null;
                }
            }

            return contactDto;
        }

        public void Delete(int id)
        {
            using (_unitOfWork)
            {
                var contact = _unitOfWork.ContactRepository.FindByCondition(x => x.Id == id).SingleOrDefault();

                if (contact != null)
                {
                    contact.IsDelete = true;
                    contact.ModifyDate = DateTime.Now;
                }

                _unitOfWork.SaveChanges();
            }
        }
    }
}
