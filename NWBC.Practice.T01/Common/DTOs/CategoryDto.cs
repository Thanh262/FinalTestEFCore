namespace Common.DTOs;

public class CategoryDto
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }
    
    public List<int> ProductIds { get; set; }
}