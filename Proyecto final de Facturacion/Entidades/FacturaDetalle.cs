using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.Entidades
{
   public class FacturaDetalle {
        [Key]
        private int factutaID { get; set; }
        private float itebis { get; set; }

      
        public int FacturaDetalleID { get; set; }
        public int FacturaID { get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IDArticulos { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public int precio { get; set; }
        public int Importe { get; set; }
        [ForeignKey("IDArticulos")]
        public virtual Articulos Articulos { get; set; }
        public FacturaDetalle()
        {
            FacturaID = 0;
            FacturaDetalleID = 0;

        }
        
        

        public FacturaDetalle(int facturaDetalleID, int factutaID, int iDArticulos,string Articulos, int cantidad,int precio,int importe)
        {
            FacturaDetalleID = facturaDetalleID;
            this.factutaID = factutaID;
            IDArticulos = iDArticulos;
            Articulo = Articulos;
           Cantidad = cantidad;
           this.precio = precio;
          Importe = importe;
        }
    }
}
