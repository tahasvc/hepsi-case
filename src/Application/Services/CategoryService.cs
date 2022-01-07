using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Core.DataAccess.Repositories;
using Core.Entities;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICacheService cacheService)
        {
            this.categoryRepository = categoryRepository;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> GetCategory(string id)
        {
            return mapper.Map<CategoryDto>(await categoryRepository.GetAsync(_ => _.Id == id));
        }

        public async Task<CategoryDto> SaveCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            var result = mapper.Map<CategoryDto>(await categoryRepository.AddAsync(category));
            cacheService.Set(string.Format(CacheKeys.GetCategoryKey, result.Id), result.ToString());

            return result;
        }

        public async Task<CategoryDto> UpdateCategory(string id, CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);

            if (id != categoryDto.Id)
                throw new MissingMemberException("Category Id mismatch");

            var categoryToUpdate = await categoryRepository.GetAsync(_ => _.Id == id);

            if (categoryToUpdate == null)
                throw new KeyNotFoundException($"Category with Id = {id} not found");

            cacheService.Set(string.Format(CacheKeys.GetCategoryKey, categoryDto.Id), categoryDto.ToString());
            category.UpdatedAt = DateTime.Now;

            return mapper.Map<CategoryDto>(await categoryRepository.UpdateAsync(category, _ => _.Id == id));
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var result = await categoryRepository.DeleteAsync(_ => _.Id == id);

            return result;
        }
    }
}
