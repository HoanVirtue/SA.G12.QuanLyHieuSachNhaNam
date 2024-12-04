using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class QuanLyHieuSachNhaNamContext : DbContext
{
    public QuanLyHieuSachNhaNamContext()
    {
    }

    public QuanLyHieuSachNhaNamContext(DbContextOptions<QuanLyHieuSachNhaNamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblChiTietHoaDon> TblChiTietHoaDons { get; set; }

    public virtual DbSet<TblChiTietNhap> TblChiTietNhaps { get; set; }

    public virtual DbSet<TblHoaDon> TblHoaDons { get; set; }

    public virtual DbSet<TblNhanvien> TblNhanviens { get; set; }

    public virtual DbSet<TblNhap> TblNhaps { get; set; }

    public virtual DbSet<TblSach> TblSaches { get; set; }

    public virtual DbSet<TblTaikhoan> TblTaikhoans { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.SMaHd, e.SMaSach });

            entity.ToTable("tblChiTietHoaDon");

            entity.Property(e => e.SMaHd)
                .HasMaxLength(20)
                .HasColumnName("sMaHD");
            entity.Property(e => e.SMaSach)
                .HasMaxLength(20)
                .HasColumnName("sMaSach");
            entity.Property(e => e.FDongia).HasColumnName("fDongia");
            entity.Property(e => e.FThanhtien).HasColumnName("fThanhtien");
            entity.Property(e => e.ISoluong).HasColumnName("iSoluong");

            entity.HasOne(d => d.SMaHdNavigation).WithMany(p => p.TblChiTietHoaDons)
                .HasForeignKey(d => d.SMaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChiTietHoaDon_tblHoaDon");

            entity.HasOne(d => d.SMaSachNavigation).WithMany(p => p.TblChiTietHoaDons)
                .HasForeignKey(d => d.SMaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChiTietHoaDon_tblSach");
        });

        modelBuilder.Entity<TblChiTietNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPn, e.SMasach });

            entity.ToTable("tblChiTietNhap");

            entity.Property(e => e.MaPn)
                .HasMaxLength(20)
                .HasColumnName("MaPN");
            entity.Property(e => e.SMasach)
                .HasMaxLength(20)
                .HasColumnName("sMasach");
            entity.Property(e => e.FDongia).HasColumnName("fDongia");
            entity.Property(e => e.FThanhtien).HasColumnName("fThanhtien");
            entity.Property(e => e.ISoluong).HasColumnName("iSoluong");

            entity.HasOne(d => d.MaPnNavigation).WithMany(p => p.TblChiTietNhaps)
                .HasForeignKey(d => d.MaPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChiTietNhap_tblNhap");

            entity.HasOne(d => d.SMasachNavigation).WithMany(p => p.TblChiTietNhaps)
                .HasForeignKey(d => d.SMasach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChiTietNhap_tblSach");
        });

        modelBuilder.Entity<TblHoaDon>(entity =>
        {
            entity.HasKey(e => e.SMaHd).HasName("PK__tblHoaDo__328E4D551579AD7F");

            entity.ToTable("tblHoaDon");

            entity.Property(e => e.SMaHd)
                .HasMaxLength(20)
                .HasColumnName("sMaHD");
            entity.Property(e => e.DNgaylap).HasColumnName("dNgaylap");
            entity.Property(e => e.FTongHd).HasColumnName("fTongHD");
            entity.Property(e => e.SMaNv)
                .HasMaxLength(20)
                .HasColumnName("sMaNV");

            entity.HasOne(d => d.SMaNvNavigation).WithMany(p => p.TblHoaDons)
                .HasForeignKey(d => d.SMaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblHoaDon_tblNhanvien");
        });

        modelBuilder.Entity<TblNhanvien>(entity =>
        {
            entity.HasKey(e => e.SMaNv).HasName("PK__tblNhanv__328E1C0FB7CCACC6");

            entity.ToTable("tblNhanvien");

            entity.HasIndex(e => e.SCccd, "UQ__tblNhanv__31AF424FA59EB373").IsUnique();

            entity.Property(e => e.SMaNv)
                .HasMaxLength(20)
                .HasColumnName("sMaNV");
            entity.Property(e => e.BGioitinh).HasColumnName("bGioitinh");
            entity.Property(e => e.BTrangthai).HasColumnName("bTrangthai");
            entity.Property(e => e.BVaitro).HasColumnName("bVaitro");
            entity.Property(e => e.DNgaysinh).HasColumnName("dNgaysinh");
            entity.Property(e => e.DNgayvaolam).HasColumnName("dNgayvaolam");
            entity.Property(e => e.FLuong).HasColumnName("fLuong");
            entity.Property(e => e.SCccd)
                .HasMaxLength(20)
                .HasColumnName("sCCCD");
            entity.Property(e => e.SDiachi)
                .HasMaxLength(255)
                .HasColumnName("sDiachi");
            entity.Property(e => e.SSdt)
                .HasMaxLength(15)
                .HasColumnName("sSDT");
            entity.Property(e => e.STenNv)
                .HasMaxLength(255)
                .HasColumnName("sTenNV");
        });

        modelBuilder.Entity<TblNhap>(entity =>
        {
            entity.HasKey(e => e.MaPn).HasName("PK__tblNhap__2725E7F0A292050E");

            entity.ToTable("tblNhap");

            entity.Property(e => e.MaPn)
                .HasMaxLength(20)
                .HasColumnName("MaPN");
            entity.Property(e => e.BLoai).HasColumnName("bLoai");
            entity.Property(e => e.DNgaylap).HasColumnName("dNgaylap");
            entity.Property(e => e.FTongGt).HasColumnName("fTongGT");
            entity.Property(e => e.SMaNv)
                .HasMaxLength(20)
                .HasColumnName("sMaNV");

            entity.HasOne(d => d.SMaNvNavigation).WithMany(p => p.TblNhaps)
                .HasForeignKey(d => d.SMaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblNhap_tblNhanvien");
        });

        modelBuilder.Entity<TblSach>(entity =>
        {
            entity.HasKey(e => e.SMasach).HasName("PK__tblSach__EA6DC7103193D482");

            entity.ToTable("tblSach");

            entity.Property(e => e.SMasach)
                .HasMaxLength(20)
                .HasColumnName("sMasach");
            entity.Property(e => e.IDongia).HasColumnName("iDongia");
            entity.Property(e => e.ISoluong).HasColumnName("iSoluong");
            entity.Property(e => e.SNxb)
                .HasMaxLength(255)
                .HasColumnName("sNXB");
            entity.Property(e => e.STenTg)
                .HasMaxLength(255)
                .HasColumnName("sTenTG");
            entity.Property(e => e.STensach)
                .HasMaxLength(255)
                .HasColumnName("sTensach");
            entity.Property(e => e.STheloai)
                .HasMaxLength(100)
                .HasColumnName("sTheloai");
        });

        modelBuilder.Entity<TblTaikhoan>(entity =>
        {
            entity.HasKey(e => e.SMaNv).HasName("PK__tblTaikh__328E1C0FCE34D502");

            entity.ToTable("tblTaikhoan");

            entity.Property(e => e.SMaNv)
                .HasMaxLength(20)
                .HasColumnName("sMaNV");
            entity.Property(e => e.SMatkhau)
                .HasMaxLength(255)
                .HasColumnName("sMatkhau");

            entity.HasOne(d => d.SMaNvNavigation).WithOne(p => p.TblTaikhoan)
                .HasForeignKey<TblTaikhoan>(d => d.SMaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTaikhoan_tblNhanvien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
