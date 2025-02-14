using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Donhang
{
    public string IdDonhang { get; set; } = null!;

    public DateOnly? NgayTao { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public string? IdNguoidung { get; set; }

    public string? IdVanchuyen { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Nguoidung? IdNguoidungNavigation { get; set; }

    public virtual Vanchuyen? IdVanchuyenNavigation { get; set; }

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();
}
