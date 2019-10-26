using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DEBO.Core.CustomExceptions;
using DEBO.Core.DomainService;
using DEBO.Core.Entity;

namespace DEBO.Core.ApplicationService.BaseService
{
    public class BaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto> :
        IBaseService<T, TKey, TInputDto, TOutputDto, TUpdateDto>
        where T : BaseEntity<TKey>
        where TInputDto : class
        where TOutputDto : class
        where TUpdateDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork,
            IMapper dataMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = dataMapper;
        }

        public IEnumerable<TOutputDto> GetAll()
        {
            var allEntities =
                _unitOfWork.Repository<T>().FindAll()
                    .Where(x => !x.IsDelete);

            return
                _mapper.ProjectTo<TOutputDto>(allEntities);
        }

        public virtual TOutputDto GetOne(TKey id)
        {
            var entity =
                _unitOfWork.Repository<T>()
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<TOutputDto>(entity);
        }

        public virtual async Task<T> InsertAsync(TInputDto entityInsertDto)
        {
            var entity = _mapper.Map<T>(entityInsertDto);
            _unitOfWork.Repository<T>().Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(TKey id, TUpdateDto entityUpdateDto)
        {
            var foundEntity =
                _unitOfWork.Repository<T>()
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (foundEntity == null)
                throw new EntityNotFoundException();

            foundEntity = _mapper.Map<T>(entityUpdateDto);
            foundEntity.Id = id;
            foundEntity.ModifyDate = DateTime.Now;

            _unitOfWork.Repository<T>().Update(foundEntity);

            await _unitOfWork.SaveChangesAsync();
            return foundEntity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var foundEntity =
                _unitOfWork.Repository<T>()
                    .FindByCondition(x =>
                        !x.IsDelete &&
                        x.Id.Equals(id))
                    .SingleOrDefault();

            if (foundEntity == null)
                throw new EntityNotFoundException();

            foundEntity.IsDelete = true;
            foundEntity.ModifyDate = DateTime.Now;

            _unitOfWork.Repository<T>().Update(foundEntity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}