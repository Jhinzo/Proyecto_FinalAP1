using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double SubTotal { get; set; }
        public double ItbisTotal { get; set; }
        public double Total { get; set; }

        [ForeignKey("FacturaId")]
        public virtual List<Ordenes> OrdenDetalle { get; set; } = new List<Ordenes>();

        public Facturas()
        {
            FacturaId =0 ;
            Fecha= DateTime.Now;
            SubTotal = 0;
            ItbisTotal = 0;
            Total= 0;
        }

        public Facturas(int facturaId, DateTime fecha, double subTotal, double itbisTotal, double total)
        {
            FacturaId = facturaId;
            Fecha = fecha;
            SubTotal = subTotal;
            ItbisTotal = itbisTotal;
            Total = total;
        }
    }
}
