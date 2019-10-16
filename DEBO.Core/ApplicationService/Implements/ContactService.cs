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
        private readonly IDataMapper _dataMapper;

        public ContactService(IUnitOfWork unitOfWork, IDataMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dataMapper = mapper;
        }

        public async Task<Contact> InsertAsync(ContactInsertDto entityInsertDto)
        {
            var contact = _dataMapper.Map<Contact>(entityInsertDto);
            _unitOfWork.ContactRepository.Create(contact);
            await _unitOfWork.SaveChangesAsync();
            return contact;
        }

        public IEnumerable<ContactOutputDto> GetAll()
        {
            var allContacts =
                _unitOfWork.ContactRepository.FindByCondition(x => !x.IsDelete);
            var contactOutputDtos =
                _dataMapper.ProjectTo<ContactOutputDto>(allContacts);
            return contactOutputDtos.ToList();
        }

        public async Task<Contact> UpdateAsync(ContactUpdateDto entityUpdateDto)
        {
            var foundContact = _unitOfWork.ContactRepository
                .FindByCondition(x => !x.IsDelete && x.Id == entityUpdateDto.Id)
                .SingleOrDefault();
            if (foundContact == null)
            {
                throw new EntityNotFoundException();
            }

            foundContact = _dataMapper.Map<Contact>(entityUpdateDto);
            foundContact.ModifyDate = DateTime.Now;
            _unitOfWork.ContactRepository.Update(foundContact);
            await _unitOfWork.SaveChangesAsync();
            return foundContact;
        }

        public ContactOutputDto GetById(int id)
        {
            var contact = _unitOfWork.ContactRepository
                .FindByCondition(x => !x.IsDelete && x.Id == id)
                .SingleOrDefault();
            if (contact == null)
            {
                throw new EntityNotFoundException();
            }

            return _dataMapper.Map<ContactOutputDto>(contact);
        }

        public async Task DeleteAsync(int id)
        {
            var contact = _unitOfWork.ContactRepository
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