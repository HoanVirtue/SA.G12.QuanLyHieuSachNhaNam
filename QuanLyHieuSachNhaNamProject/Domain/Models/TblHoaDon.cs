using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblHoaDon
{
    public string SMaHd { get; set; } = null!;

    public string SMaNv { get; set; } = null!;

    public DateOnly DNgaylap { get; set; }

    public double FTongHd { get; set; }

    public virtual TblNhanvien SMaNvNavigation { get; set; } = null!;

    public virtual ICollection<TblChiTietHoaDon> TblChiTietHoaDons { get; set; } = new List<TblChiTietHoaDon>();
}
