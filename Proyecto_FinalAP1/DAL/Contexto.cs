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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source= Data/Database.db");
        }
    }
}
