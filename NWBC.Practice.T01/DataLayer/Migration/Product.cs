using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataLayer.Migration;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int CategoryId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    [JsonIgnore]
    public Category Category { get; set; } 
}
