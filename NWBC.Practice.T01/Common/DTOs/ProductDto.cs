namespace Common.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int CategoryId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }
    
}