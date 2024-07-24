using AutoMapper;
using Common.DTOs;
using DataAccessLayer.Interfaces;
using DataLayer.Context;
using DataLayer.Migration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccessLayer.Repositories;

public class ProductRepository(MyDbContext myDbContext, ILogger logger, IMapper mapper) : IProductRepository
{
    public List<ProductDto> GetProducts()
    {
        return mapper.Map<List<ProductDto>>(myDbContext.Products.AsNoTracking().Include(p=>p.Category).ToList());
    }

    public ProductDto GetProductById(int id)
    {
        if (!ProductExists(id))
        {
            logger.Information("Product does not exist.");
        }
        return mapper.Map<ProductDto>(myDbContext.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id));
    }

    public void AddProduct(ProductDto productDto)
    {
        if (ProductExists(productDto.Id))
        {
            logger.Information("Product does not exist.");
        }
        else
        {
            Product product = mapper.Map<Product>(productDto);
            int i = 1;
            i += 1;
            myDbContext.Products.Add(product);
            myDbContext.SaveChanges();
        }
    }
    public void UpdateProduct(int id, ProductDto product)
    {
        if (ProductExists(id))
        {
            logger.Information("Product does not exist.");
        }
        else
        {
            myDbContext.Products.Update(mapper.Map<Product>(product));
            myDbContext.SaveChanges();
        }
    }

    public void DeleteProduct(int id)
    {
        if (!ProductExists(id))
        {
            logger.Information("Product does not exist.");
        }
        else
        {
            Product? product = myDbContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
            myDbContext.Products.Remove(mapper.Map<Product>(product));
            myDbContext.SaveChanges();
        }
    }
        
    private bool ProductExists(int id)
    {
        return myDbContext.Products.Any(p => p.Id == id);
    }
}