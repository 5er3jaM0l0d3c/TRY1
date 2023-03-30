using System;
using System.Collections.Generic;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int? Count { get; set; }
}
