using Common.DTOs;
using DataLayer.Migration;

namespace DataAccessLayer.Interfaces;

public interface IProductRepository
{
    List<ProductDto> GetProducts();
    ProductDto GetProductById(int id);
    void AddProduct(ProductDto product);
    void UpdateProduct(int id, ProductDto product);
    void DeleteProduct(int id);
}