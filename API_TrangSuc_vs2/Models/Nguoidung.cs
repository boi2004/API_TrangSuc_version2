using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Nguoidung
{
    public string IdNguoidung { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Sđt { get; set; }

    public string? Email { get; set; }

    public string? Diachi { get; set; }

    public DateOnly? Ngaysinh { get; set; }

    public string? Thanhvien { get; set; }

    public string? ThongTinThanhToan { get; set; }

    public bool? XoaTamThoi { get; set; }

    public string? IdVaitro { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual Vaitro? IdVaitroNavigation { get; set; }
}
