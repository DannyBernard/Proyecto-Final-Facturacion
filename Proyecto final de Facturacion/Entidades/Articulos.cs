using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.Entidades
{
  public  class Articulos
    {
        [Key]
        public int IDArticulos { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Itebis { get; set; }
        public float Costo { get; set; }
        public float Ganancia { get; set; }
        public DateTime FechaDevencimineto { get; set; }


        public Articulos()
        {
           
        }public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
