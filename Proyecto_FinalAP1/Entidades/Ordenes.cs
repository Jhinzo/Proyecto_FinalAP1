using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    class Ordenes
    {
        public int OrdenId { get; set; }
        public int FacturaId { get; set; }
        public int PlatilloId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }

    }
}
