using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<object> GetProduct(string id);
        Task<ProductDto> SaveProducts(ProductDto productDto);
        Task<ProductDto> UpdateProduct(string id, ProductDto productDto);
        Task<bool> DeleteProduct(string id);
    }
}
