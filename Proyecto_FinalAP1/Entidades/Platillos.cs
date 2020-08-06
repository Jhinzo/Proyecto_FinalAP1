using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    class Platillos
    {
        [Key]
        public int PlatilloId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
    }
}
