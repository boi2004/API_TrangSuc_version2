using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Thanhtoan
{
    public string IdThanhtoan { get; set; } = null!;

    public DateOnly? NgayThanhToan { get; set; }

    public string? Pttt { get; set; }

    public decimal? Gia { get; set; }

    public string? IdDonhang { get; set; }

    public virtual Donhang? IdDonhangNavigation { get; set; }
}
