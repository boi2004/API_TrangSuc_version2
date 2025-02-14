using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Sanpham
{
    public string IdSanpham { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Mota { get; set; }

    public decimal? Gia { get; set; }

    public int? Soluong { get; set; }

    public string? Chatlieu { get; set; }

    public string? KichThuoc { get; set; }

    public string? Danhgia { get; set; }

    public string? IdLoai { get; set; }

    public string? IdThuonghieu { get; set; }

    public string? IdCtsp { get; set; }

    public virtual Chitietsp? IdCtspNavigation { get; set; }

    public virtual Loai? IdLoaiNavigation { get; set; }

    public virtual Thuonghieu? IdThuonghieuNavigation { get; set; }

    public virtual ICollection<Kho> Khos { get; set; } = new List<Kho>();

    public virtual ICollection<Chitietdonhang> IdCthds { get; set; } = new List<Chitietdonhang>();

    public virtual ICollection<Khuyenmai> IdKhuyenmais { get; set; } = new List<Khuyenmai>();

    public virtual ICollection<Phukien> IdPhukiens { get; set; } = new List<Phukien>();
}
