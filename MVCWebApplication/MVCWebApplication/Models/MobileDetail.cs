using System;
using System.Collections.Generic;

namespace MVCWebApplication.Models;

public partial class MobileDetail
{
    public int Id { get; set; }

    public string MobileName { get; set; } = null!;

    public long Price { get; set; }

    public int Ram { get; set; }

    public int Storage { get; set; }
}
