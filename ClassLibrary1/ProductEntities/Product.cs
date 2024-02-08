using System;
using System.Collections.Generic;

namespace ClassLibrary1.ProductEntities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? AnimalId { get; set; }

    public virtual TargetAnimal? Animal { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
