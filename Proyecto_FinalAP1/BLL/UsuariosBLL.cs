using Microsoft.EntityFrameworkCore;
using Proyecto_FinalAP1.DAL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_FinalAP1.BLL
{
    class UsuariosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Usuarios.Any(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Usuarios Usuario)
        {
            if (Usuario.UsuarioId == 0)
                return Insertar(Usuario);
            else
                return Modificar(Usuario);

        }

        private static bool Insertar(Usuarios Usuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                Usuario.Contraseña = GetSHA256(Usuario.Contraseña);
                if (contexto.Usuarios.Add(Usuario) != null) { paso = (contexto.SaveChanges() > 0); }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuarios Usuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Usuario.Contraseña = GetSHA256(Usuario.Contraseña);
            try
            {
                contexto.Entry(Usuario).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var Usuario = contexto.Usuarios.Find(id);
                if (Usuario != null)
                {
                    contexto.Usuarios.Remove(Usuario);
                    paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios Usuario = new Usuarios();
            try
            {
                Usuario = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Usuario;
        }

        public static List<Usuarios> GetList()
        {
            Contexto contexto = new Contexto();
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = contexto.Usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = contexto.Usuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

       

        public static bool Validar(string nombreusuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var esValido = from usuario in contexto.Usuarios
                               where usuario.UserName == nombreusuario
                               && usuario.Contraseña == GetSHA256(clave)
                               select usuario;
                if (esValido.Count() > 0) { paso = true; }
                else { paso = false; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}

