using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Phukien
{
    public string IdPhukien { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Mota { get; set; }

    public decimal? Gia { get; set; }

    public virtual ICollection<Sanpham> IdSanphams { get; set; } = new List<Sanpham>();
}
