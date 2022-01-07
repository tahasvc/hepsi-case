using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Core.DataAccess.Repositories;
using Core.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper, ICacheService cacheService, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.cacheService = cacheService;
        }
        public async Task<object> GetProduct(string id)
        {
            var cacheProduct = await cacheService.Get(string.Format(CacheKeys.GetProductKey, id));
            dynamic productDetails;

            if (string.IsNullOrEmpty(cacheProduct))
            {
                var product = mapper.Map<ProductDto>(await productRepository.GetByIdAsync(id));

                if (product == null)
                    throw new MissingMemberException("Product Id mismatch");

                var category = await GetCategory(product.CategoryId);

                cacheService.Set(string.Format(CacheKeys.GetProductKey, product.Id), product.ToString());
                cacheService.Set(string.Format(CacheKeys.GetCategoryKey, category.Id), category.ToString());
                productDetails = JsonConvert.DeserializeObject<ExpandoObject>(product.ToString());
                productDetails.category = category;

                return productDetails;
            }

            dynamic obj = JsonSerializer.Deserialize<ExpandoObject>(cacheProduct);
            string cacheCategory = await cacheService.Get(string.Format(CacheKeys.GetCategoryKey, obj.categoryId));

            if (cacheCategory == null)
            {
                var res = await GetCategory(obj.categoryId);
                if (res != null)
                    cacheCategory = res.ToString();
            }


            productDetails = JsonConvert.DeserializeObject<ExpandoObject>(cacheProduct);
            productDetails.category = JsonConvert.DeserializeObject<ExpandoObject>(cacheCategory ?? string.Empty);

            return productDetails;
        }

        public async Task<ProductDto> SaveProducts(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            var result = await productRepository.AddAsync(product);
            cacheService.Set(string.Format(CacheKeys.GetProductKey, result.Id), productDto.ToString());

            return mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> UpdateProduct(string id, ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);

            if (id != productDto.Id)
                throw new MissingMemberException("Product Id mismatch");

            var productToUpdate = await productRepository.GetAsync(_ => _.Id == id);

            if (productToUpdate == null)
                throw new KeyNotFoundException($"Product with Id = {id} not found");

            product.UpdatedAt=DateTime.Now;
            await productRepository.UpdateAsync(id, product);

            cacheService.Set(string.Format(CacheKeys.GetProductKey, productDto.Id), productDto.ToString());

            return productDto;

        }

        public async Task<bool> DeleteProduct(string id)
        {
            return await productRepository.DeleteAsync(_ => _.Id == id);
        }

        private async Task<CategoryDto> GetCategory(string id)
        {
            return mapper.Map<CategoryDto>(await categoryRepository.GetByIdAsync(id));
        }
    }
}
