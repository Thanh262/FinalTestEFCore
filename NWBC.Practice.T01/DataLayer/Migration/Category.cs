using System;
using System.Collections.Generic;

namespace DataLayer.Migration;

public class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public  ICollection<Product> Products { get; set; } 
}
