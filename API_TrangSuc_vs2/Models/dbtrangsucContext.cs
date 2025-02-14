using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_TrangSuc_vs2.Models;

public partial class dbtrangsucContext : DbContext
{
    public dbtrangsucContext()
    {
    }

    public dbtrangsucContext(DbContextOptions<dbtrangsucContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietsp> Chitietsps { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Phukien> Phukiens { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    public virtual DbSet<Vaitro> Vaitros { get; set; }

    public virtual DbSet<Vanchuyen> Vanchuyens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dbTrangSuc.mssql.somee.com;Database=dbTrangSuc;User Id=nguyen_SQLLogin_1;Password=*Nguyen2004;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => e.IdCthd).HasName("PK__CHITIETD__69C7F5C3BC559493");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.IdCthd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_cthd");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.IdDonhang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_donhang");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.IdDonhangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.IdDonhang)
                .HasConstraintName("FK__CHITIETDO__id_do__05D8E0BE");

            entity.HasMany(d => d.IdSanphams).WithMany(p => p.IdCthds)
                .UsingEntity<Dictionary<string, object>>(
                    "Co",
                    r => r.HasOne<Sanpham>().WithMany()
                        .HasForeignKey("IdSanpham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Co__id_sanpham__0F624AF8"),
                    l => l.HasOne<Chitietdonhang>().WithMany()
                        .HasForeignKey("IdCthd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Co__id_cthd__0E6E26BF"),
                    j =>
                    {
                        j.HasKey("IdCthd", "IdSanpham").HasName("PK__Co__5C1099D9BC87A4B7");
                        j.ToTable("Co");
                        j.IndexerProperty<string>("IdCthd")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_cthd");
                        j.IndexerProperty<string>("IdSanpham")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_sanpham");
                    });
        });

        modelBuilder.Entity<Chitietsp>(entity =>
        {
            entity.HasKey(e => e.IdCtsp).HasName("PK__CHITIETS__69C792399DC3541D");

            entity.ToTable("CHITIETSP");

            entity.Property(e => e.IdCtsp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_ctsp");
            entity.Property(e => e.HuongDanSuDung)
                .HasMaxLength(500)
                .HasColumnName("huong_dan_su_dung");
            entity.Property(e => e.MoTaChiTiet)
                .HasMaxLength(500)
                .HasColumnName("mo_ta_chi_tiet");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.IdDonhang).HasName("PK__DONHANG__638F44CEC7F0ABF4");

            entity.ToTable("DONHANG");

            entity.Property(e => e.IdDonhang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_donhang");
            entity.Property(e => e.IdNguoidung)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_NGUOIDUNG");
            entity.Property(e => e.IdVanchuyen)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_vanchuyen");
            entity.Property(e => e.NgayTao).HasColumnName("ngay_tao");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tongtien");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(200)
                .HasColumnName("trangthai");

            entity.HasOne(d => d.IdNguoidungNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.IdNguoidung)
                .HasConstraintName("FK__DONHANG__id_NGUO__02084FDA");

            entity.HasOne(d => d.IdVanchuyenNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.IdVanchuyen)
                .HasConstraintName("FK__DONHANG__id_vanc__02FC7413");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.IdKho).HasName("PK__KHO__D4963894D0FF021B");

            entity.ToTable("KHO");

            entity.Property(e => e.IdKho)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_kho");
            entity.Property(e => e.IdSanpham)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_sanpham");
            entity.Property(e => e.NgayNhap).HasColumnName("ngay_nhap");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.Khos)
                .HasForeignKey(d => d.IdSanpham)
                .HasConstraintName("FK__KHO__id_sanpham__0B91BA14");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.IdKhuyenmai).HasName("PK__KHUYENMA__13570C8483698305");

            entity.ToTable("KHUYENMAI");

            entity.Property(e => e.IdKhuyenmai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_khuyenmai");
            entity.Property(e => e.DieuKien)
                .HasMaxLength(200)
                .HasColumnName("dieu_kien");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.NgayBd).HasColumnName("ngay_bd");
            entity.Property(e => e.NgayKt).HasColumnName("ngay_kt");
            entity.Property(e => e.PhanTramGiam)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("phan_tram_giam");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");

            entity.HasMany(d => d.IdSanphams).WithMany(p => p.IdKhuyenmais)
                .UsingEntity<Dictionary<string, object>>(
                    "Sohuu",
                    r => r.HasOne<Sanpham>().WithMany()
                        .HasForeignKey("IdSanpham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Sohuu__id_sanpha__1332DBDC"),
                    l => l.HasOne<Khuyenmai>().WithMany()
                        .HasForeignKey("IdKhuyenmai")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Sohuu__id_khuyen__123EB7A3"),
                    j =>
                    {
                        j.HasKey("IdKhuyenmai", "IdSanpham").HasName("PK__Sohuu__2680609E8CE8BD89");
                        j.ToTable("Sohuu");
                        j.IndexerProperty<string>("IdKhuyenmai")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_khuyenmai");
                        j.IndexerProperty<string>("IdSanpham")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_sanpham");
                    });
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.IdLoai).HasName("PK__LOAI__9A03AA72DFFE8905");

            entity.ToTable("LOAI");

            entity.Property(e => e.IdLoai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_loai");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdNguoidung).HasName("PK__NGUOIDUN__E4E899917C82B66E");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.IdNguoidung)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_NGUOIDUNG");
            entity.Property(e => e.Diachi)
                .HasMaxLength(200)
                .HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.IdVaitro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_vaitro");
            entity.Property(e => e.Ngaysinh).HasColumnName("ngaysinh");
            entity.Property(e => e.Sđt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sđt");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");
            entity.Property(e => e.Thanhvien)
                .HasMaxLength(200)
                .HasColumnName("thanhvien");
            entity.Property(e => e.ThongTinThanhToan)
                .HasMaxLength(200)
                .HasColumnName("thong_tin_thanh_toan");
            entity.Property(e => e.XoaTamThoi).HasColumnName("xoa_tam_thoi");

            entity.HasOne(d => d.IdVaitroNavigation).WithMany(p => p.Nguoidungs)
                .HasForeignKey(d => d.IdVaitro)
                .HasConstraintName("FK__NGUOIDUNG__id_va__7A672E12");
        });

        modelBuilder.Entity<Phukien>(entity =>
        {
            entity.HasKey(e => e.IdPhukien).HasName("PK__PHUKIEN__84E8BE5B2B5C76A7");

            entity.ToTable("PHUKIEN");

            entity.Property(e => e.IdPhukien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_phukien");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");

            entity.HasMany(d => d.IdSanphams).WithMany(p => p.IdPhukiens)
                .UsingEntity<Dictionary<string, object>>(
                    "Kem",
                    r => r.HasOne<Sanpham>().WithMany()
                        .HasForeignKey("IdSanpham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Kem__id_sanpham__1AD3FDA4"),
                    l => l.HasOne<Phukien>().WithMany()
                        .HasForeignKey("IdPhukien")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Kem__id_phukien__19DFD96B"),
                    j =>
                    {
                        j.HasKey("IdPhukien", "IdSanpham").HasName("PK__Kem__B13FD2413895E946");
                        j.ToTable("Kem");
                        j.IndexerProperty<string>("IdPhukien")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_phukien");
                        j.IndexerProperty<string>("IdSanpham")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_sanpham");
                    });
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__SANPHAM__5D76C1A21729B368");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.IdSanpham)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_sanpham");
            entity.Property(e => e.Chatlieu)
                .HasMaxLength(200)
                .HasColumnName("chatlieu");
            entity.Property(e => e.Danhgia)
                .HasMaxLength(200)
                .HasColumnName("danhgia");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.IdCtsp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_ctsp");
            entity.Property(e => e.IdLoai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_loai");
            entity.Property(e => e.IdThuonghieu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_thuonghieu");
            entity.Property(e => e.KichThuoc)
                .HasMaxLength(200)
                .HasColumnName("kich_thuoc");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdCtspNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdCtsp)
                .HasConstraintName("FK__SANPHAM__id_ctsp__7F2BE32F");

            entity.HasOne(d => d.IdLoaiNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdLoai)
                .HasConstraintName("FK__SANPHAM__id_loai__7D439ABD");

            entity.HasOne(d => d.IdThuonghieuNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdThuonghieu)
                .HasConstraintName("FK__SANPHAM__id_thuo__7E37BEF6");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.IdThanhtoan).HasName("PK__THANHTOA__257DA41AA3C063ED");

            entity.ToTable("THANHTOAN");

            entity.Property(e => e.IdThanhtoan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_thanhtoan");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.IdDonhang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_donhang");
            entity.Property(e => e.NgayThanhToan).HasColumnName("ngay_thanh_toan");
            entity.Property(e => e.Pttt)
                .HasMaxLength(200)
                .HasColumnName("pttt");

            entity.HasOne(d => d.IdDonhangNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.IdDonhang)
                .HasConstraintName("FK__THANHTOAN__id_do__08B54D69");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdThuonghieu).HasName("PK__THUONGHI__8FCB194CC8042AA0");

            entity.ToTable("THUONGHIEU");

            entity.Property(e => e.IdThuonghieu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_thuonghieu");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("mota");
            entity.Property(e => e.Quocgia)
                .HasMaxLength(200)
                .HasColumnName("quocgia");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");

            entity.HasMany(d => d.IdKhos).WithMany(p => p.IdThuonghieus)
                .UsingEntity<Dictionary<string, object>>(
                    "Nhap",
                    r => r.HasOne<Kho>().WithMany()
                        .HasForeignKey("IdKho")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Nhap__id_kho__17036CC0"),
                    l => l.HasOne<Thuonghieu>().WithMany()
                        .HasForeignKey("IdThuonghieu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Nhap__id_thuongh__160F4887"),
                    j =>
                    {
                        j.HasKey("IdThuonghieu", "IdKho").HasName("PK__Nhap__D2827AC5082F474A");
                        j.ToTable("Nhap");
                        j.IndexerProperty<string>("IdThuonghieu")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_thuonghieu");
                        j.IndexerProperty<string>("IdKho")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("id_kho");
                    });
        });

        modelBuilder.Entity<Vaitro>(entity =>
        {
            entity.HasKey(e => e.IdVaitro).HasName("PK__VAITRO__33F4C028B4BACBAE");

            entity.ToTable("VAITRO");

            entity.Property(e => e.IdVaitro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_vaitro");
            entity.Property(e => e.Chucnang).HasColumnName("chucnang");
            entity.Property(e => e.Ten)
                .HasMaxLength(200)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Vanchuyen>(entity =>
        {
            entity.HasKey(e => e.IdVanchuyen).HasName("PK__VANCHUYE__17A6B28F37C613E5");

            entity.ToTable("VANCHUYEN");

            entity.Property(e => e.IdVanchuyen)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id_vanchuyen");
            entity.Property(e => e.DiaChiShip)
                .HasMaxLength(200)
                .HasColumnName("dia_chi_ship");
            entity.Property(e => e.NgayShip).HasColumnName("ngay_ship");
            entity.Property(e => e.NgayShipThucTe).HasColumnName("ngay_ship_thuc_te");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(200)
                .HasColumnName("trangthai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
