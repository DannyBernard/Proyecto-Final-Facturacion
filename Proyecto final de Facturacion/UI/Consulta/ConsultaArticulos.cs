using Proyecto_final_de_Facturacion.BLL;
using Proyecto_final_de_Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final_de_Facturacion.UI.Consulta
{
    public partial class ConsultaArticulos : Form
    {
        RepositoryBase<Articulos> repositoryBase;
        Expression<Func<Articulos, bool>> filtro = x => true;
        public ConsultaArticulos()
        {
            InitializeComponent();
            repositoryBase = new RepositoryBase<Articulos>();
        }

        private bool Validar(int error)
        {
            bool paso = true; 
            int num = 0;
            if (error == 1 && string.IsNullOrEmpty(CriteriotextBox.Text))
            {
                errorProvider1.SetError(CriteriotextBox, "Campo Vacio");
                paso = true;
            }
            if(error ==2&& int.TryParse(CriteriotextBox.Text,out num) == false)
            {
                errorProvider1.SetError(CriteriotextBox, "Ingrese un numero");
                paso = true;
            }
            if(error==3&& int.TryParse(CriteriotextBox.Text,out num) == true)
            {
                errorProvider1.SetError(CriteriotextBox, "Ingrese caracter");
                paso = true;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Id
                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        filtro = x => x.IDArticulos == id;

                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Articulo no Exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    }

                case 1://Descripcion
                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Descripcion no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    }
                case 2: //Importe
                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        float importe = Convert.ToSingle(CriteriotextBox.Text);
                        filtro = x => x.Costo == importe;
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Importe no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;


                    }
                case 3://Ganancia
                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        float Ganancia = Convert.ToSingle(CriteriotextBox.Text);
                        filtro = x => x.Ganancia == Ganancia;
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {

                            MessageBox.Show("Ganancia no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;

                      case 4://precio

                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        float precio = Convert.ToSingle(CriteriotextBox.Text);
                        filtro = x => x.Precio == precio;
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {

                            MessageBox.Show("Precio no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;

                case 5: //Cantidad

                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int Cantidad = Convert.ToInt32(CriteriotextBox.Text);
                        filtro = x => x.Cantidad == Cantidad;
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {

                            MessageBox.Show("Precio no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;

                case 6: //Itebis
                    if (Validar(1))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Llenar Campo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        float itebis= Convert.ToSingle(CriteriotextBox.Text);
                        filtro = x => x.Itebis== itebis;
                        if (repositoryBase.GetList(filtro).Count() == 0)
                        {

                            MessageBox.Show("Precio no exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;
                case 7://todo
                    filtro = x => true;
                    break;
            }
            errorProvider1.DataSource = repositoryBase.GetList(filtro);
            CriteriotextBox.Clear();
            errorProvider1.Clear();
        }
    }
}
