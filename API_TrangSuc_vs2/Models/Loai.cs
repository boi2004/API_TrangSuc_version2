using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Loai
{
    public string IdLoai { get; set; } = null!;

    public string? Ten { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
