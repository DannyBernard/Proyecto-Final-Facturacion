using Proyecto_final_de_Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.DAL
{
   public class Contexto: DbContext
    {
        public DbSet<Usuario> Usario { get; set; }
        public DbSet<Articulos> Articulos{ get; set; }
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Credito> Creditos { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
