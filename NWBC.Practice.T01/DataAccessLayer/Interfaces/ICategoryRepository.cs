using Common.DTOs;
using DataLayer.Migration;

namespace DataAccessLayer.Interfaces;

public interface ICategoryRepository
{
    List<CategoryDto> GetCategories();
    CategoryDto? GetCategoryById(int id);
    void AddCategory(CategoryDto category);
    void UpdateCategory(int id, CategoryDto category);
    void DeleteCategory(int id);
   // bool CategoryExists(int id);
}