using Proyecto_final_de_Facturacion.DAL;
using Proyecto_final_de_Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.BLL
{
    public class FacturacionBLL
    {
       // RepositoryBase<Usuario> repository;
        public static bool Guardar(Factura factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Usuario usuario = new Usuario();
            try
            {
                if (contexto.Facturas.Add(factura) != null)
                {
                    foreach(var item in factura.Detalle)
                    {
                        contexto.Articulos.Find(item.IDArticulos).Cantidad -= item.Cantidad;
                    }
                    contexto.Usario.Find(factura.IDUsuario).TotalVentas += factura.ToTal;
                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Modificar(Factura factura)
        {
            RepositoryBase<Usuario> repository = new RepositoryBase<Usuario>(new Contexto());
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var facturas = Buscar(factura.FactutaID);
                var usuario = contexto.Usario.Find(factura.IDUsuario);
                var usuarioAnterior = contexto.Usario.Find(factura.IDUsuario);

                if(factura.IDUsuario!= factura.IDUsuario)
                {
                    usuario.TotalVentas += factura.ToTal;
                    usuario.TotalVentas -= factura.ToTal;
                    repository.Modificar(usuario);
                    repository.Modificar(usuarioAnterior);

                }
                if(factura != null)
                {
                    foreach(var item in factura.Detalle)
                    {
                        contexto.Articulos.Find(item.IDArticulos).Cantidad += item.Cantidad;
                        if(!factura.Detalle.ToList().Exists(x => x.FacturaDetalleID == item.FacturaDetalleID))
                        {
                            item.Articulos = null;
                            contexto.Entry(item).State = EntityState.Deleted;

                        }
                        
                    }
                    foreach (var item in factura.Detalle)
                    {
                        contexto.Articulos.Find(item.Articulos).Cantidad -= item.Cantidad;
                        var estado = item.FacturaDetalleID > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }
                    Factura entradaAnt = Buscar(factura.FactutaID);

                    decimal diferencia;

                    diferencia = factura.ToTal- entradaAnt.ToTal;
                    RepositoryBase<Usuario> repositoryb = new RepositoryBase<Usuario>(new Contexto());
                    Usuario usuarios = repositoryb.Buscar(factura.IDUsuario);

                    usuario.TotalVentas += diferencia;

                    repositoryb.Modificar(usuario);

                    contexto.Entry(factura).State = EntityState.Modified;
                    if (contexto.SaveChanges() > 0)
                    {
                        paso = true;

                    }
                    contexto.Dispose();


                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Factura factura = new Factura();
                if(factura != null)
                {
                    foreach(var item in factura.Detalle)
                    {
                        contexto.Articulos.Find(item.IDArticulos).Cantidad += item.Cantidad;
                    }
                    contexto.Usario.Find(factura.IDUsuario).TotalVentas -= factura.Cantidad;
                    factura.Detalle.Count();
                    contexto.Facturas.Remove(factura);
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static Factura Buscar(int id)
        {
            Factura factura = new Factura();
            Contexto contexto = new Contexto();
            try
            {
                factura = contexto.Facturas.Find(id);
                if(factura != null)
                {
                    factura.Detalle.Count();
                    foreach(var item in factura.Detalle)
                    {
                        string des = item.Articulos.Descripcion;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return factura;
        }
        public static List<Factura>GetList(Expression<Func<Factura, bool>> expression)
        {
            List<Factura> facturas = new List<Factura>();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Facturas.Where(expression).ToList();
                foreach(var item in facturas)
                {
                    item.Detalle.Count();

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return facturas; 
        }
        public static int CacularImporte(int precio, int cantidad)
        {
            return precio = cantidad;
        }
        public static decimal CacularItebis(decimal subTotal)
        {

            return Convert.ToDecimal(subTotal) + Convert.ToDecimal(0.18);

        }
        public static decimal CarcularTotal(decimal subTotal, decimal itebis)
        {
            return Convert.ToDecimal(subTotal) + Convert.ToDecimal(itebis);
        }
        
    }
}
