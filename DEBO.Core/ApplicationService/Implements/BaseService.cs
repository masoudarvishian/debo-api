using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.CustomExceptions;
using DEBO.Core.DomainService;
using DEBO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                _unitOfWork.BaseRepository.FindAll();

            return
                _dataMapper.ProjectTo<TOutputDto>(allEntities);
        }

        public virtual IEnumerable<TOutputDto> GetAll(
            Expression<Func<T, bool>> expression)
        {
            var allEntities =
                _unitOfWork.BaseRepository
                    .FindByCondition(expression);

            return
                _dataMapper.ProjectTo<TOutputDto>(allEntities);
        }

        public virtual TOutputDto GetOne(Expression<Func<T, bool>> expression)
        {
            var entity =
                _unitOfWork.BaseRepository.FindByCondition(expression)
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
            _unitOfWork.BaseRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(TKey id,
            TUpdateDto entityUpdateDto)
        {
            var foundEntity =
                _unitOfWork.BaseRepository.FindById(id);

            if (foundEntity == null)
                throw new EntityNotFoundException();

            foundEntity = _dataMapper.Map<T>(entityUpdateDto);
            foundEntity.ModifyDate = DateTime.Now;

            _unitOfWork.BaseRepository.Update(foundEntity);

            await _unitOfWork.SaveChangesAsync();
            return foundEntity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var foundCategory = _unitOfWork.BaseRepository.FindById(id);

            if (foundCategory == null)
                throw new EntityNotFoundException();

            foundCategory.IsDelete = true;
            foundCategory.ModifyDate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}