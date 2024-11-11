using System;
using System.Collections.Generic;

namespace MasterPaulTestDemka.Models;

public partial class MaterialType
{
    public int IdMaterial { get; set; }

    public string TypeMaterial { get; set; } = null!;

    public double MaterialScrapPercentage { get; set; }
}
