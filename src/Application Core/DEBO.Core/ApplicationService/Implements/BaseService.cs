using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.CustomExceptions;
using DEBO.Core.DomainService;
using DEBO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEBO.Core.ApplicationService.Implements
{
    public class BaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto> :
        IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
        where T : BaseEntity<TKey>
        where TInputDto : class
        where TOutputDto : class
        where TUpdateDto : class
    {
        private readonly IUnitOfWork<T> _unitOfWork;
        private readonly IDataMapper _dataMapper;

        public BaseService(IUnitOfWork<T> unitOfWork,
            IDataMapper dataMapper)
        {
            _unitOfWork = unitOfWork;
            _dataMapper = dataMapper;
        }

        public IEnumerable<TOutputDto> GetAll()
        {
            var allEntities =
                _unitOfWork.Repository.FindAll()
                    .Where(x => !x.IsDelete);

            return
                _dataMapper.ProjectTo<TOutputDto>(allEntities);
        }

        public virtual TOutputDto GetOne(TKey id)
        {
            var entity =
                _unitOfWork.Repository
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return _dataMapper.Map<TOutputDto>(entity);
        }

        public virtual async Task<T> InsertAsync(TInputDto entityInsertDto)
        {
            var entity = _dataMapper.Map<T>(entityInsertDto);
            _unitOfWork.Repository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(TKey id, TUpdateDto entityUpdateDto)
        {
            var foundEntity =
                _unitOfWork.Repository
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (foundEntity == null)
                throw new EntityNotFoundException();

            foundEntity = _dataMapper.Map<T>(entityUpdateDto);
            foundEntity.Id = id;
            foundEntity.ModifyDate = DateTime.Now;

            _unitOfWork.Repository.Update(foundEntity);

            await _unitOfWork.SaveChangesAsync();
            return foundEntity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var foundEntity =
                _unitOfWork.Repository
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (foundEntity == null)
                throw new EntityNotFoundException();

            foundEntity.IsDelete = true;
            foundEntity.ModifyDate = DateTime.Now;

            _unitOfWork.Repository.Update(foundEntity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}