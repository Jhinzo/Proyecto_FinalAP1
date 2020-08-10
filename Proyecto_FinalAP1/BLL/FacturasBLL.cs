using Microsoft.EntityFrameworkCore;
using Proyecto_FinalAP1.DAL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace Proyecto_FinalAP1.BLL
{
    class FacturasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                esOk = contexto.Facturas.Any(e => e.FacturaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Guardar(Facturas Compra)
        {
            if (Compra.FacturaId == 0)
                return Insertar(Compra);
            else
                return Modificar(Compra);
        }

        private static bool Insertar(Facturas Factura)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Facturas.Add(Factura) != null) { paso = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Facturas Factura)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalle Where TareaId={Factura.FacturaId}");
                foreach (var item in Factura.OrdenDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
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
            bool esOk = false;
            try
            {
                var Factura = contexto.Facturas.Find(id);
                if (Factura != null)
                {
                    contexto.Facturas.Remove(Factura);
                    esOk = (contexto.SaveChanges() > 0);
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
            return esOk;
        }

        public static Facturas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Facturas Compra = new Facturas();
            try
            {
                Compra = contexto.Facturas.Include(x => x.OrdenDetalle)
                    .Where(x => x.FacturaId == id)
                    .SingleOrDefault();
                if (Compra == null)
                {
                    MessageBox.Show("Compra no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Compra;
        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Facturas> Lista = new List<Facturas>();
            try
            {
                Lista = contexto.Facturas.Where(criterio).ToList();
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
