using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterPaulTestDemka.Models;

public partial class Partner
{
    public int IdPartners { get; set; }

    public string? PartnersType { get; set; }

    public string? PartnersName { get; set; }

    public string? Director { get; set; }

    public string? PartnerEmail { get; set; }

    public double? PartnerPhone { get; set; }

    public string? PartnerSLegalAddress { get; set; }

    public double? Inn { get; set; }

    public int? Rating { get; set; }

    public void discount()
    {
        int sum = Helper.DataBase.PartnerProducts.Where(x => x.PartnerName == IdPartners).Select(z => z.ProductQuantity).Sum();


    } 

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
