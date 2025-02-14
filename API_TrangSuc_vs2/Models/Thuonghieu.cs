using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Thuonghieu
{
    public string IdThuonghieu { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Quocgia { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();

    public virtual ICollection<Kho> IdKhos { get; set; } = new List<Kho>();
}
