using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Routing;

namespace API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> logger;
        private readonly IProductService productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await productService.GetProduct(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            return Created("", await productService.SaveProducts(productDto));
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto, string id)
        {
            return Ok(await productService.UpdateProduct(id, productDto));
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await productService.DeleteProduct(id));
        }
    }
}
