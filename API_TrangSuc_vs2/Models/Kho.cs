using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Kho
{
    public string IdKho { get; set; } = null!;

    public DateOnly? NgayNhap { get; set; }

    public int? Soluong { get; set; }

    public string? IdSanpham { get; set; }

    public virtual Sanpham? IdSanphamNavigation { get; set; }

    public virtual ICollection<Thuonghieu> IdThuonghieus { get; set; } = new List<Thuonghieu>();
}
