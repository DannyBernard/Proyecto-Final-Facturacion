using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.Entidades
{
  public class Credito
    {
        [Key]
        public int IDCredito { get; set; }
        public String Descripcion { get; set; }
        public float Monto { get; set; }
        public int Cuotas { get; set; }
        public float Interes { get; set; }

        public Credito()
        {
            IDCredito = 0;
            Descripcion = string.Empty;
            Monto = 0;
            Cuotas = 0;
            Interes = 0;
        }
    }
}
