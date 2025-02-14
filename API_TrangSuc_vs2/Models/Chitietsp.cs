using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Chitietsp
{
    public string IdCtsp { get; set; } = null!;

    public string? HuongDanSuDung { get; set; }

    public string? MoTaChiTiet { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
