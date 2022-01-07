using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Services;
using AutoMapper;
using Moq;
using Core.DataAccess.Repositories;
using Core.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTests.Services
{
    [TestClass]
    public class ProductServiceUnitTest
    {
        private static ProductService productService;
        private static Mock<IProductRepository> mockProductRepository;
        private static Mock<IMapper> mockMapper;
        private static Mock<ICacheService> mockCacheService;
        private static Mock<ICategoryRepository> mockCategoryRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockMapper = new Mock<IMapper>();
            mockCacheService = new Mock<ICacheService>();
            mockCategoryRepository = new Mock<ICategoryRepository>();

            productService = new ProductService(mockProductRepository.Object, mockMapper.Object, mockCacheService.Object, mockCategoryRepository.Object);

            mockCacheService.Setup(_ => _.Set(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DistributedCacheEntryOptions>()));
        }

        [TestMethod]
        public void GetProduct_With_ProductId_And_CategoryId_IsNotNull()
        {
            const string id = "61d8360b1f5073d4cf08013b";
            mockCacheService.Setup(_ => _.Get(It.IsAny<string>())).ReturnsAsync("");
            mockProductRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Product() { CategoryId = "61d8360b1f5073d4cf08013b" });
            mockCategoryRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Category() { });
            var result = productService.GetProduct(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public async Task GetProduct_With_ProductId_And_CategoryId_Exception()
        {
            const string id = "61d8360b1f5073d4cf08013b";
            mockCacheService.Setup(_ => _.Get(It.IsAny<string>())).ReturnsAsync("");
            mockProductRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Product() { CategoryId = "61d8360b1f5073d4cf08013b" });
            mockCategoryRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Category() { });

            await productService.GetProduct(id);
        }

        [TestMethod]
        public async Task GetProduct_Without_ProductId_And_With_Cache_CategoryId_Null_IsNotNull()
        {
            const string id = "61d8360b1f5073d4cf08013b";
            mockCacheService.Setup(_ => _.Get(It.IsAny<string>())).ReturnsAsync(JsonConvert.SerializeObject(new {categoryId="4121231312"}));
            mockProductRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Product() { CategoryId = "61d8360b1f5073d4cf08013b" });
            mockCategoryRepository.Setup(_ => _.GetByIdAsync(id)).ReturnsAsync(new Category() { });
            mockCacheService.Setup(_ => _.Get(string.Format(CacheKeys.GetCategoryKey, "12312321"))).ReturnsAsync("Test");
            var result = await productService.GetProduct(id);

            Assert.IsNotNull(result);
        }
    }
}
