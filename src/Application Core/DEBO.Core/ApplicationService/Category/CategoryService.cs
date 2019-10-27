﻿using AutoMapper;
using DEBO.Core.ApplicationService.BaseService;
using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEBO.Core.ApplicationService.Category
{
    using CustomExceptions;
    using Entity.Category;
    using Entity.CategoryGroup;
    using Entity.CategoryGroupCategory;

    public class CategoryService :
        BaseService<Category, int, CategoryInputDto, CategoryOutputDto,
            CategoryUpdateDto>,
        ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork,
            mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public override async Task<Category> InsertAsync(
            CategoryInputDto entityInsertDto)
        {
            var category = _mapper.Map<Category>(entityInsertDto);

            var categoryGroup = _unitOfWork.Repository<CategoryGroup>()
                .FindByCondition(x => x.Id == entityInsertDto.CategoryGroupId)
                .SingleOrDefault();

            if (categoryGroup == null)
            {
                throw new EntityNotFoundException("categoryGroup Not Found!");
            }

            category.CategoryGroupLinks =
<<<<<<< HEAD
                new List<CategoryGroupCategory>
                {
                    new CategoryGroupCategory
=======
                new List<Entity.CategoryGroupCategory.CategoryGroupCategory>
                {
                    new Entity.CategoryGroupCategory.CategoryGroupCategory
>>>>>>> 10e51a8ae0193e5053c099131e6805a6503023a0
                    {
                        Category = category,
                        CategoryGroup = categoryGroup
                    }
                };

            _unitOfWork.Repository<Category>()
                .Create(category);
            await _unitOfWork.SaveChangesAsync();
            return category;
        }
    }
}