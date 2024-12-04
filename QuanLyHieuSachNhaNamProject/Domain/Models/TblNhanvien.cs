using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblNhanvien
{
    public string SMaNv { get; set; } = null!;

    public string STenNv { get; set; } = null!;

    public DateOnly? DNgaysinh { get; set; }

    public bool BGioitinh { get; set; }

    public string? SDiachi { get; set; }

    public DateOnly DNgayvaolam { get; set; }

    public string? SSdt { get; set; }

    public double FLuong { get; set; }

    public bool BVaitro { get; set; }

    public bool BTrangthai { get; set; }

    public string? SCccd { get; set; }

    public virtual ICollection<TblHoaDon> TblHoaDons { get; set; } = new List<TblHoaDon>();

    public virtual ICollection<TblNhap> TblNhaps { get; set; } = new List<TblNhap>();

    public virtual TblTaikhoan? TblTaikhoan { get; set; }
}
