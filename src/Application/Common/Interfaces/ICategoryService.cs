using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategory(string id);
        Task<CategoryDto> SaveCategory(CategoryDto productDto);
        Task<CategoryDto> UpdateCategory(string id, CategoryDto productDto);
        Task<bool> DeleteCategory(string id);
    }
}
