﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230316082150_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Khoa", b =>
                {
                    b.Property<int>("KhoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KHOA_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaId"));

                    b.Property<string>("SoHieuKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SO_HIEU_KHOA");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_KHOA");

                    b.HasKey("KhoaId");

                    b.ToTable("KHOA");
                });

            modelBuilder.Entity("API.Models.SinhVien", b =>
                {
                    b.Property<int>("SinhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SINH_VIEN_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinhVienId"));

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GIOI_TINH");

                    b.Property<int>("KhId")
                        .HasColumnType("int");

                    b.Property<string>("MaSV")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MA_SINH_VIEN");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_SINH");

                    b.Property<string>("TenSV")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TEN_SINH_VIEN");

                    b.HasKey("SinhVienId");

                    b.HasIndex("KhId");

                    b.ToTable("SINH_VIEN");
                });

            modelBuilder.Entity("API.Models.SinhVien", b =>
                {
                    b.HasOne("API.Models.Khoa", "Khoa")
                        .WithMany("SinhViens")
                        .HasForeignKey("KhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("API.Models.Khoa", b =>
                {
                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
