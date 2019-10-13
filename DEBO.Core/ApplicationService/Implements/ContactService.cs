using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Contact> InsertAsync(ContactInsertDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            _unitOfWork.ContactRepository.Create(contact);
            await _unitOfWork.SaveChangesAsync();

            return contact;
        }

        public IEnumerable<ContactOutputDto> GetAll()
        {
            List<ContactOutputDto> contactDtos = new List<ContactOutputDto>();

            var allContacts = _unitOfWork.ContactRepository.FindByCondition(x => !x.IsDelete);

            var mappedContatDtos = _mapper.ProjectTo<ContactOutputDto>(allContacts);

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

            foundContact = _mapper.Map<Contact>(contactDto);
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

           return _mapper.Map<ContactOutputDto>(contact);
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
