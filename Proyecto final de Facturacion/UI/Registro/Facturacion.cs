using Proyecto_final_de_Facturacion.BLL;
using Proyecto_final_de_Facturacion.DAL;
using Proyecto_final_de_Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final_de_Facturacion.UI.Registro
{
    public partial class Facturacion : Form
    {
        List<FacturaDetalle> detalles;
       public  RepositoryBase<Articulos> repository;
        public Facturacion()
        {
            InitializeComponent();
            LlenarImporte();
           repository = new RepositoryBase<Articulos>(new Contexto());
            LlenarCombo();
            detalles = new List<FacturaDetalle>();
        }
        decimal itebis = 0;
        decimal total = 0;
      public void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
           // DescripciontextBox.Clear();
            CantidadnumericUpDown.Value = 0;
            SubTotaltextBox.Text = 0.ToString();
            ITBtextBox.Text = 0.ToString();
            TotaltextBox.Text = 0.ToString();
            PreciotextBox.Text = 0.ToString();
            CantidadnumericUpDown.Value = 0;
            
            importetextBox.Text = 0.ToString();
            
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;
        }

        public void LlenarImporte()
        {
            int precio, cantidad;


            precio = ToInt(PreciotextBox.Text);
            cantidad = ToInt(CantidadnumericUpDown.Value);

            importetextBox.Text = FacturacionBLL.CacularImporte(precio, cantidad).ToString();
            
        }
        private Factura LlenarClase()
        {
            Factura factura = new Factura();
            factura.FactutaID = Convert.ToInt32(IDnumericUpDown.Value);
            factura.IDUsuario = Convert.ToInt32((UsuariocomboBox.Text));
            factura.FechaFactura = FechadateTimePicker.Value;
            factura.IDArticulos = Convert.ToInt32(IDProductonumericUpDown.Value);
           // factura.Descripcion = DescripciontextBox.Text;
            factura.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            factura.SubTotal = Convert.ToSingle(SubTotaltextBox.Text);
            factura.Itebis = Convert.ToDecimal(ITBtextBox.Text);
            factura.ToTal = Convert.ToDecimal(TotaltextBox.Text);

            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                factura.AgregarDetalle 
                 (
                 ToInt(item.Cells["FacturaDetalleID"].Value),
                 factura.FactutaID,
                 ToInt(item.Cells["IDArticulo"].Value),
                 Convert.ToString(item.Cells["Articulos"].Value),
                 ToInt(item.Cells["Cantidad"].Value),
                 ToInt(item.Cells["Precio"].Value),
                 ToInt(item.Cells["Importe"].Value)
                 );

               }
            return factura;
        }
        private void Llenarcampo(Factura factura)
        {
            IDnumericUpDown.Value = factura.FactutaID;
            FechadateTimePicker.Value = factura.FechaFactura;
           DescripciontextBox.Text = factura.Descripcion;
            SubTotaltextBox.Text = factura.SubTotal.ToString();
            ITBtextBox.Text = factura.Itebis.ToString();
            TotaltextBox.Text = factura.ToTal.ToString();
            dataGridView1.DataSource = factura.Detalle;

        }
        private void LlenarCombo()
        {
            RepositoryBase<Usuario> repositoryBase = new RepositoryBase<Usuario>(new Contexto());
            UsuariocomboBox.DataSource = repositoryBase.GetList(c => true);
            UsuariocomboBox.ValueMember = "IDUsuario";
            UsuariocomboBox.DisplayMember = "Nombre";

            RepositoryBase<Articulos> repositoryBaseA = new RepositoryBase<Articulos>();
            ArticuloscomboBox.ValueMember = "IDArticulos";
            ArticuloscomboBox.DisplayMember = "Descripcion";
        }  

        public void QuitarCulumnas()
        {
            dataGridView1.Columns["Articulos"].Visible = false;
            dataGridView1.Columns["FacturaID"].Visible = false;
            dataGridView1.Columns["IDFacturaDetalle"].Visible = false;

        }
        

        public static string RetornarDescripcion(string nombre)
        {

            RepositoryBase<Articulos> repositoryBase = new RepositoryBase<Articulos>(new Contexto());
            string descripcion = string.Empty;
            var lista = repositoryBase.GetList(x => x.Descripcion.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Descripcion;
            }

            return descripcion;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            /*
            List<FacturaDetalle> facturaDetalles = new List<FacturaDetalle>();
            if (dataGridView1.DataSource != null)
            {
                facturaDetalles = (List<FacturaDetalle>)dataGridView1.DataSource;
            }
            RepositoryBase<Articulos> repository = new RepositoryBase<Articulos>(new Contexto());
            Articulos articulos = (Articulos)ArticuloscomboBox.SelectedItem;
            //Articulos articulo = new Articulos();
         /*   if ((int)CantidadnumericUpDown.Value > articulos.Cantidad)
            {
                MessageBox.Show("Cantidad no Dispoble para la venta", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            
            {
                facturaDetalles.Add(
                    new FacturaDetalle(facturaDetalleID: 0,
                    factutaID: Convert.ToInt32(IDnumericUpDown.Value),
                    iDArticulos: (int)IDProductonumericUpDown.Value,
                   Articulos:(string)RetornarDescripcion(ArticuloscomboBox.Text),
                   cantidad: Convert.ToInt32(CantidadnumericUpDown.Value),
                   precio: Convert.ToInt32(PreciotextBox.Text),
                   importe: Convert.ToInt32(importetextBox.Text)));


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = facturaDetalles;
                QuitarCulumnas();


            }
            if (CantidadnumericUpDown.Value == 0)
            {
                MessageBox.Show("Intrudusca una cantidad valida");

            }
            int x = Convert.ToInt32(CantidadnumericUpDown.Value);
            articulos.Cantidad -= x;

            decimal subtotal = 0;
            foreach(var item in facturaDetalles)
            {
                subtotal += item.Importe;
            }
            SubTotaltextBox.Text = subtotal.ToString();
            itebis = FacturacionBLL.CacularItebis(Convert.ToDecimal(SubTotaltextBox.Text));
            ITBtextBox.Text = itebis.ToString();
            total = FacturacionBLL.CarcularTotal(Convert.ToDecimal(SubTotaltextBox.Text), Convert.ToDecimal(ITBtextBox.Text));
            TotaltextBox.Text = total.ToString();
            */

            FacturaDetalle facturaDetalle = new FacturaDetalle();
            facturaDetalle.IDArticulos = ArticuloscomboBox.SelectedIndex;
            facturaDetalle.Cantidad = (int)CantidadnumericUpDown.Value;
            facturaDetalle.FacturaID = (int)IDnumericUpDown.Value;
            facturaDetalle.Importe =Convert.ToInt32(importetextBox.Text);
            //facturaDetalle.precio = Convert.ToInt32(PreciotextBox.Text);

            detalles.Add(facturaDetalle);

            dataGridView1.DataSource = detalles.ToList();

            decimal subtotal = 0;
            foreach (var item in detalles)
            {
                subtotal += item.Importe;
            }
            SubTotaltextBox.Text = subtotal.ToString();
            itebis = FacturacionBLL.CacularItebis(Convert.ToDecimal(SubTotaltextBox.Text));
            ITBtextBox.Text = itebis.ToString();
            total = FacturacionBLL.CarcularTotal(Convert.ToDecimal(SubTotaltextBox.Text), Convert.ToDecimal(ITBtextBox.Text));
            TotaltextBox.Text = total.ToString();


        }

        private void ArticuloscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositoryBase<Articulos> repository = new RepositoryBase<Articulos>();
            foreach (var item in repository.GetList(x => x.Descripcion == ArticuloscomboBox.Text))
                {
                PreciotextBox.Text = item.Precio.ToString();
            }
            
        }
    }
}
