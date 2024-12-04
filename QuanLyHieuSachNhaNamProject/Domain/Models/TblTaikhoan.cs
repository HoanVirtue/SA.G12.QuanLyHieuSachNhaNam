using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TblTaikhoan
{
    public string SMaNv { get; set; } = null!;

    public string SMatkhau { get; set; } = null!;

    public virtual TblNhanvien SMaNvNavigation { get; set; } = null!;
}
