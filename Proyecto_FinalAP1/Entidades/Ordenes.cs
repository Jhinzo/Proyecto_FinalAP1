using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public int FacturaId { get; set; }
        public int PlatilloId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }

        public Ordenes(int ordenId, int facturaId, int platilloId, string nombre, int cantidad, double importe)
        {
            OrdenId = ordenId;
            FacturaId = facturaId;
            PlatilloId = platilloId;
            Nombre = nombre;
            Cantidad = cantidad;
            Importe = importe;
        }

        public Ordenes()
        {
            OrdenId = 0;
            FacturaId = 0;
            PlatilloId = 0;
            Nombre = String.Empty;
            Cantidad = 0;
            Importe = 0;
        }
    }
}
