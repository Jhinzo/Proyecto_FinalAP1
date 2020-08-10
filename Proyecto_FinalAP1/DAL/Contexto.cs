using Microsoft.EntityFrameworkCore;
using Proyecto_FinalAP1.BLL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_FinalAP1.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Platillos> Platillos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source= Data/Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Contraseña = UsuariosBLL.GetSHA256("123456"),
                Nombre = "Manager",
                Apellido = "Manager",
                NivelUsuario = "Administrador",
                Cedula = "4028907891",
                UserName = "Admin",
                Telefono="8099081234",
                Fecha = DateTime.Now
            }); ;
        }
    }
}
