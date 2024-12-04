using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblSach
{
    public string SMasach { get; set; } = null!;

    public string STensach { get; set; } = null!;

    public string? STenTg { get; set; }

    public double IDongia { get; set; }

    public int ISoluong { get; set; }

    public string? SNxb { get; set; }

    public string? STheloai { get; set; }

    public virtual ICollection<TblChiTietHoaDon> TblChiTietHoaDons { get; set; } = new List<TblChiTietHoaDon>();

    public virtual ICollection<TblChiTietNhap> TblChiTietNhaps { get; set; } = new List<TblChiTietNhap>();
}
