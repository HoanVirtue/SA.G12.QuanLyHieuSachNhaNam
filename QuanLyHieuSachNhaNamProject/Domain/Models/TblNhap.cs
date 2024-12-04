using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblNhap
{
    public string MaPn { get; set; } = null!;

    public string SMaNv { get; set; } = null!;

    public DateOnly DNgaylap { get; set; }

    public bool BLoai { get; set; }

    public double FTongGt { get; set; }

    public virtual TblNhanvien SMaNvNavigation { get; set; } = null!;

    public virtual ICollection<TblChiTietNhap> TblChiTietNhaps { get; set; } = new List<TblChiTietNhap>();
}
