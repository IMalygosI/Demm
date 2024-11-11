using System;
using System.Collections.Generic;

namespace MasterPaulTestDemka.Models;

public partial class ProductType
{
    public int IdTypeProduct { get; set; }

    public string? TypeProduct { get; set; }

    public double? ProductTypeFactor { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
