using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblChiTietHoaDon
{
    public string SMaHd { get; set; } = null!;

    public string SMaSach { get; set; } = null!;

    public int ISoluong { get; set; }

    public double FDongia { get; set; }

    public double FThanhtien { get; set; }

    public virtual TblHoaDon SMaHdNavigation { get; set; } = null!;

    public virtual TblSach SMaSachNavigation { get; set; } = null!;
}
