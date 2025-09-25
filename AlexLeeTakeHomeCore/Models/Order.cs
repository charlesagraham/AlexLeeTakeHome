using System;
using System.Collections.Generic;

namespace AlexLeeTakeHomeCore.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? Amount { get; set; }
}
