using System;
using System.Collections.Generic;

namespace MasterPaulTestDemka.Models;

public partial class Product
{
    public int IdProducts { get; set; }

    public int TypeProducts { get; set; }

    public string ProductName { get; set; } = null!;

    public int Article { get; set; }

    public int MinimumCostForAPartner { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType TypeProductsNavigation { get; set; } = null!;
}
