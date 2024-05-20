using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        public async Task<ActionResult<Product>> Add(ProductCreateDto product)
        { 
            var newProduct = _mapper.Map<ProductCreateDto,Product>(product);
            await _productRepository.AddAsync(newProduct);
            return Created("added successfully", newProduct);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Product>> Update(ProductCreateDto product)
        {
            var updatedProduct = _mapper.Map<ProductCreateDto, Product>(product);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            await _productRepository.UpdateAsync(updatedProduct);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _productRepository.DeleteAsync(id);
            return Ok("has deletd");
        } 
    }
}

