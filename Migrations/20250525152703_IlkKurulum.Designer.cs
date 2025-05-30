﻿// <auto-generated />
using System;
using HastaneAppv4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneAppv4.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20250525152703_IlkKurulum")]
    partial class IlkKurulum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HastaneAppv4.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brans")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int?>("KlinikId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("KlinikId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Hasta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Ilac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ilaclar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Klinik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Klinikler");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Kullanicilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("HastaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("Saat")
                        .HasColumnType("time");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("HastaneAppv4.Models.RandevuIlac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IlacId")
                        .HasColumnType("int");

                    b.Property<int>("RandevuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IlacId");

                    b.HasIndex("RandevuId");

                    b.ToTable("RandevuIlaclar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Doktor", b =>
                {
                    b.HasOne("HastaneAppv4.Models.Doktor", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("DoktorId");

                    b.HasOne("HastaneAppv4.Models.Klinik", "Klinik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("KlinikId");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Kullanicilar", b =>
                {
                    b.HasOne("HastaneAppv4.Models.Role", "Rol")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Randevu", b =>
                {
                    b.HasOne("HastaneAppv4.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneAppv4.Models.Hasta", "Hasta")
                        .WithMany()
                        .HasForeignKey("HastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");
                });

            modelBuilder.Entity("HastaneAppv4.Models.RandevuIlac", b =>
                {
                    b.HasOne("HastaneAppv4.Models.Ilac", "Ilac")
                        .WithMany("RandevuIlaclar")
                        .HasForeignKey("IlacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneAppv4.Models.Randevu", "Randevu")
                        .WithMany("RandevuIlaclari")
                        .HasForeignKey("RandevuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilac");

                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Doktor", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Ilac", b =>
                {
                    b.Navigation("RandevuIlaclar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Klinik", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Randevu", b =>
                {
                    b.Navigation("RandevuIlaclari");
                });

            modelBuilder.Entity("HastaneAppv4.Models.Role", b =>
                {
                    b.Navigation("Kullanicilar");
                });
#pragma warning restore 612, 618
        }
    }
}
