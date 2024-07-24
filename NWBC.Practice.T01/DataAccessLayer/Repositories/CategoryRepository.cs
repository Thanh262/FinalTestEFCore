using AutoMapper;
using Common.DTOs;
using DataAccessLayer.Interfaces;
using DataLayer.Context;
using DataLayer.Migration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccessLayer.Repositories;

public class CategoryRepository(MyDbContext myDbContext , ILogger logger, IMapper mapper) : ICategoryRepository
{
    public List<CategoryDto> GetCategories()
    {
        return mapper.Map<List<CategoryDto>>(myDbContext.Categories.Include(c=>c.Products).AsNoTracking().ToList());
    }

    public CategoryDto? GetCategoryById(int id)
    {
        if (!CategoryExists(id))
        {
            logger.Information("Category doesn't exist.");
        }

        return mapper.Map<CategoryDto>(myDbContext.Categories.FirstOrDefault(c => c.Id == id));
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        Category category = mapper.Map<Category>(categoryDto);

        if (CategoryExists(categoryDto.Id))
        {
            logger.Error("Category Id Duplicate.");
        }
        else
        {
            
            myDbContext.Categories.Add(category);
            myDbContext.SaveChanges();
        }
        
    }

    public void UpdateCategory(int id, CategoryDto category)
    {
        if (!CategoryExists(id))
        {
            logger.Information("Category doesn't exist.");
        }
        myDbContext.Categories.Update(mapper.Map<Category>(category));
        myDbContext.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        if (!CategoryExists(id))
        {
            logger.Information("Category doesn't exist.");
        }

        Category category = myDbContext.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
        
        myDbContext.Categories.Remove(mapper.Map<Category>(category));
        myDbContext.SaveChanges();
    }

    public bool CategoryExists(int id)
    {
        return myDbContext.Categories.Any(c => c != null && c.Id == id);
    }
}