#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCookers_WebAPI.Data;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Product;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo=   repo;
        }

        // GET: api/Products
        [HttpGet]
        [Route("AllProduct")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
           var a = await _repo.GetAllProducts();
            return Ok(a);
        }

        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProduct(Guid id)
        {
            
            return Ok();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<ProductReadDto>> AddProduct(ProductCreateDto productCreateDto)
        {

            return Ok(_repo.AddProduct(productCreateDto));
        }
    }
}
