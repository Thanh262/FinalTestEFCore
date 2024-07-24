using AutoMapper;
using Common.DTOs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NWBC.Practice.T01.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductRepository productRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ProductDto> productDtos =  productRepository.GetProducts();
        return Ok(productDtos);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetProductById(int id)
    {
        ProductDto productDto = productRepository.GetProductById(id);
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    { 
        productRepository.AddProduct(productDto);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
    {
        productRepository.UpdateProduct(id, productDto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        productRepository.DeleteProduct(id);
        return Ok();
    }
}