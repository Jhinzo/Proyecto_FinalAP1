using Microsoft.EntityFrameworkCore;
using Proyecto_FinalAP1.DAL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Proyecto_FinalAP1.BLL
{
    class PlatillosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Platillos.Any(e => e.PlatilloId == id);
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

        public static bool Guardar(Platillos Client)
        {
            return Insertar(Client);
        }

        private static bool Insertar(Platillos Client)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Platillos.Add(Client) != null) { paso = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(PlatillosBLL Client)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(Client).State = EntityState.Modified;
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
                var Client = contexto.Platillos.Find(id);
                if (Client != null)
                {
                    contexto.Platillos.Remove(Client);
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

        public static Platillos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Platillos Client = new Platillos();
            try
            {
                Client = contexto.Platillos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Client;
        }


        public static List<Platillos> GetList(Expression<Func<Platillos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Platillos> Lista = new List<Platillos>();
            try
            {
                Lista = contexto.Platillos.Where(criterio).ToList();
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
    }
}
