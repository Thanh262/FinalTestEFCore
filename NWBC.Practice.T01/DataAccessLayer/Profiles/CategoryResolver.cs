using AutoMapper;
using Common.DTOs;
using DataLayer.Context;
using DataLayer.Migration;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Profiles;

public class CategoryResolver: IValueResolver<ProductDto, Product, Category>
{
    private MyDbContext _myDbContext;
    public CategoryResolver(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    } 
    
    public Category Resolve(ProductDto source, Product destination, Category destMember, ResolutionContext context)
    {
        return _myDbContext.Categories
            //.Include(c=>c.Products)
            .FirstOrDefault(s => s.Id == source.CategoryId);
    }
}