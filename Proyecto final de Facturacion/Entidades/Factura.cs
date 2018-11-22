using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.Entidades
{
    public class Factura
    {
        [Key]
        public int FactutaID { get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IDArticulos { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal ToTal { get; set; }

        public virtual ICollection<FacturaDetalle> Detalle { get; set; }

        public Factura()
        {
            this.Detalle = new List<FacturaDetalle>();
            FechaFactura = DateTime.Now;
        }
        public void AgregarDetalle(int FacturaDetalleID, int FacturaID, int IDArticulos,string Articulos, int Cantidad,int precio, int importe)
        {
            Detalle.Add(new FacturaDetalle(FacturaDetalleID, FactutaID, IDArticulos,Articulos ,Cantidad, precio,importe));
        }

        
    }
}