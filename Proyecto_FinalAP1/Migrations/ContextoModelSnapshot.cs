﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_FinalAP1.DAL;

namespace Proyecto_FinalAP1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Mesa")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Facturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("ItbisTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("SubTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("FacturaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacturaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Importe")
                        .HasColumnType("REAL");

                    b.Property<double>("Itbis")
                        .HasColumnType("REAL");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("OrdenId");

                    b.HasIndex("FacturaId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Platillos", b =>
                {
                    b.Property<int>("PlatilloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("PlatilloId");

                    b.ToTable("Platillos");
                });

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contraseña")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Apellido = "Manager",
                            Cedula = "4028907891",
                            Contraseña = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            Fecha = new DateTime(2020, 8, 10, 13, 54, 44, 68, DateTimeKind.Local).AddTicks(6930),
                            NivelUsuario = "Administrador",
                            Nombre = "Manager",
                            Telefono = "8099081234",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Proyecto_FinalAP1.Entidades.Ordenes", b =>
                {
                    b.HasOne("Proyecto_FinalAP1.Entidades.Facturas", null)
                        .WithMany("OrdenDetalle")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
