using Common.DTOs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NWBC.Practice.T01.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<CategoryDto> categoryDtos= categoryRepository.GetCategories();
        return Ok(categoryDtos);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        categoryRepository.GetCategoryById(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
    {
        categoryRepository.AddCategory(categoryDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        categoryRepository.UpdateCategory(id, categoryDto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        categoryRepository.DeleteCategory(id);
        return Ok();
    }
    
}