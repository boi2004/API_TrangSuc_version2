using System;
using System.Collections.Generic;

namespace API_TrangSuc_vs2.Models;

public partial class Vaitro
{
    public string IdVaitro { get; set; } = null!;

    public string? Ten { get; set; }

    public int? Chucnang { get; set; }

    public virtual ICollection<Nguoidung> Nguoidungs { get; set; } = new List<Nguoidung>();
}
