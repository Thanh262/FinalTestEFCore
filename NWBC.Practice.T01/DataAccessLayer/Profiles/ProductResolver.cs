using AutoMapper;
using Common.DTOs;
using DataLayer.Context;
using DataLayer.Migration;

namespace DataAccessLayer.Profiles;

public class ProductResolver :  IValueResolver<CategoryDto, Category, ICollection<Product>>
{
    private MyDbContext _myDbContext;

    public ProductResolver(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }
    
    public ICollection<Product> Resolve(
        CategoryDto source,
        Category destination,
        ICollection<Product> destMember, 
        ResolutionContext context)
    {
        return _myDbContext.Products
            .Where(s => source.ProductIds.Contains(s.Id))
            .ToList();
    }
}