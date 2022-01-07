using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await categoryService.GetCategory(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            return Created("", await categoryService.SaveCategory(categoryDto));
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CategoryDto categoryDto)
        {
            return Ok(await categoryService.UpdateCategory(id, categoryDto));
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await categoryService.DeleteCategory(id));
        }
    }
}
