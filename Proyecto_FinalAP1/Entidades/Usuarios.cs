using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_FinalAP1.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string NivelUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
    }
}
