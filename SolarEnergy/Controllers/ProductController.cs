using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.DbContext;
using SolarEnergy.Dtos;
using SolarEnergy.Services;

namespace SolarEnergy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _productRepository.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Product = await _productRepository.GetByIdAsync(id);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(ProductCreateDto product)
        { 
            var newProduct= _mapper.Map<ProductCreateDto,Product>(product);
            await _productRepository.AddAsync(newProduct);
            return Created("added successfully",newProduct);
        }

        // <summary>
        // end point for update
        // </summary>
        // <param name = "car" ></ param >
        // < param name="id"></param>
        // <returns>updated car</returns>

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(Product product, int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
           // existingProduct.FilePath = product.FilePath;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
          //  existingProduct.Images = product.Images;
            await _productRepository.UpdateAsync(existingProduct);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _productRepository.DeleteAsync(id);
            return Ok("has deletd");
        }

        
    }
}

