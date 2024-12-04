using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblChiTietNhap
{
    public string MaPn { get; set; } = null!;

    public string SMasach { get; set; } = null!;

    public int ISoluong { get; set; }

    public double FDongia { get; set; }

    public double FThanhtien { get; set; }

    public virtual TblNhap MaPnNavigation { get; set; } = null!;

    public virtual TblSach SMasachNavigation { get; set; } = null!;
}
