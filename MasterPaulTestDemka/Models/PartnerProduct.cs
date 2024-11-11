using System;
using System.Collections.Generic;

namespace MasterPaulTestDemka.Models;

public partial class PartnerProduct
{
    public int IdPartnerProducts { get; set; }

    public int Products { get; set; }

    public int PartnerName { get; set; }

    public int ProductQuantity { get; set; }

    public DateOnly DateOfSale { get; set; }

    public virtual Partner PartnerNameNavigation { get; set; } = null!;

    public virtual Product ProductsNavigation { get; set; } = null!;
}
