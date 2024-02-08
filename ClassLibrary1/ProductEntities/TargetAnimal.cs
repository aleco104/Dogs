using System;
using System.Collections.Generic;

namespace ClassLibrary1.ProductEntities;

public partial class TargetAnimal
{
    public int AnimalId { get; set; }

    public string AnimalName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
