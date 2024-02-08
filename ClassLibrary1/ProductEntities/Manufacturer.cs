﻿using System;
using System.Collections.Generic;

namespace ClassLibrary1.ProductEntities;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
