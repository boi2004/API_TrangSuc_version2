using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Chitietdonhang
{
    public string IdCthd { get; set; } = null!;

    public int? Soluong { get; set; }

    public decimal? Gia { get; set; }

    public string? IdDonhang { get; set; }

    public virtual Donhang? IdDonhangNavigation { get; set; }

    public virtual ICollection<Sanpham> IdSanphams { get; set; } = new List<Sanpham>();
}
