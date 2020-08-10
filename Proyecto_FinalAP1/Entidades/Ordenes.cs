using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public int FacturaId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public double Itbis { get; set; }

        public Ordenes(int facturaId, string nombre, int cantidad, double precio, double importe, double itbis)
        {
            FacturaId = facturaId;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Itbis = itbis;
        }

        public Ordenes()
        {
            OrdenId = 0;
            FacturaId = 0;
            Nombre = String.Empty;
            Precio = 0;
            Cantidad = 0;
            Importe = 0;
            Itbis = 0;
        }
    }
}
