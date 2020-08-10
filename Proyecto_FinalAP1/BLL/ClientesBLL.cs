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
    class ClientesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Clientes.Any(e => e.ClienteId == id);
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

        public static bool Guardar(Clientes Client)
        {
            if (Client.ClienteId == 0)
            {
                return Insertar(Client);
            }
            else
                return Modificar(Client);
            
        }

        private static bool Insertar(Clientes Client)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Clientes.Add(Client) != null) { paso = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Clientes Client)
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
                var Client = contexto.Clientes.Find(id);
                if (Client != null)
                {
                    contexto.Clientes.Remove(Client);
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

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes Client = new Clientes();
            try
            {
                Client = contexto.Clientes.Find(id);
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

        public static List<Clientes> GetList()
        {
            Contexto contexto = new Contexto();
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = contexto.Clientes.ToList();
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = contexto.Clientes.Where(criterio).ToList();
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
