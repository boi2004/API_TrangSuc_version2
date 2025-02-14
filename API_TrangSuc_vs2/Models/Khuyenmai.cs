using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Khuyenmai
{
    public string IdKhuyenmai { get; set; } = null!;

    public string? Ten { get; set; }

    public decimal? PhanTramGiam { get; set; }

    public DateOnly? NgayBd { get; set; }

    public DateOnly? NgayKt { get; set; }

    public string? Mota { get; set; }

    public string? DieuKien { get; set; }

    public virtual ICollection<Sanpham> IdSanphams { get; set; } = new List<Sanpham>();
}
