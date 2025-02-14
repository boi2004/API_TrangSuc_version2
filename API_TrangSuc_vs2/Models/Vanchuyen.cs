using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Vanchuyen
{
    public string? DiaChiShip { get; set; }

    public DateOnly? NgayShip { get; set; }

    public DateOnly? NgayShipThucTe { get; set; }

    public string? Trangthai { get; set; }

    public string IdVanchuyen { get; set; } = null!;

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
}
