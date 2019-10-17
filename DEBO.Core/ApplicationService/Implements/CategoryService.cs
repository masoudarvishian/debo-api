using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.Category.Dtos;

namespace DEBO.Core.ApplicationService.Implements
{
    public class CategoryService :
        BaseService<Category, int, CategoryInsertDto, CategoryOutputDto,
            CategoryUpdateDto>, ICategoryService
    {
        private readonly IUnitOfWork<Category> _unitOfWork;
        private readonly IDataMapper _dataMapper;

        public CategoryService(IUnitOfWork<Category> unitOfWork,
            IDataMapper dataMapper) : base(unitOfWork, dataMapper)
        {
            _unitOfWork = unitOfWork;
            _dataMapper = dataMapper;
        }

        //public IEnumerable<CategoryOutputDto> GetAll()
        //{
        //    var allCategories =
        //        _unitOfWork.BaseRepository
        //            .FindByCondition(x => !x.IsDelete);

        //    return
        //        _dataMapper.ProjectTo<CategoryOutputDto>(allCategories);
        //}

        //public CategoryOutputDto GetById(int id)
        //{
        //    var category =
        //        _unitOfWork.BaseRepository.FindByCondition(x =>
        //                !x.IsDelete && x.Id == id)
        //            .SingleOrDefault();

        //    if (category == null)
        //    {
        //        throw new EntityNotFoundException();
        //    }

        //    return _dataMapper.Map<CategoryOutputDto>(category);
        //}

        //public async Task<Category> InsertAsync(
        //    CategoryInsertDto entityInsertDto)
        //{
        //    var category = _dataMapper.Map<Category>(entityInsertDto);
        //    _unitOfWork.BaseRepository.Create(category);
        //    await _unitOfWork.SaveChangesAsync();
        //    return category;
        //}

        //public async Task<Category> UpdateAsync(
        //    CategoryUpdateDto entityUpdateDto)
        //{
        //    var foundCategory = _unitOfWork.BaseRepository
        //        .FindByCondition(x => !x.IsDelete && x.Id == entityUpdateDto.Id)
        //        .SingleOrDefault();

        //    if (foundCategory == null)
        //        throw new EntityNotFoundException();

        //    foundCategory = _dataMapper.Map<Category>(entityUpdateDto);
        //    foundCategory.ModifyDate = DateTime.Now;
        //    await _unitOfWork.SaveChangesAsync();
        //    return foundCategory;
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var foundCategory = _unitOfWork.BaseRepository
        //        .FindByCondition(x => !x.IsDelete && x.Id == id)
        //        .SingleOrDefault();

        //    if (foundCategory == null)
        //        throw new EntityNotFoundException();

        //    foundCategory.IsDelete = true;
        //    foundCategory.ModifyDate = DateTime.Now;
        //    await _unitOfWork.SaveChangesAsync();
        //}
    }
}