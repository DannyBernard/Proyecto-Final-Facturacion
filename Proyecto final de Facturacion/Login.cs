using Proyecto_final_de_Facturacion.BLL;
using Proyecto_final_de_Facturacion.Entidades;
using Proyecto_final_de_Facturacion.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final_de_Facturacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /*
            PanelPrincipal panelPrincipal = new PanelPrincipal();
            panelPrincipal.Show();
          */
            string usuario = UsariotextBox.Text;
            string clave = PasswordtextBox.Text;
            RepositoryBase<Usuario> repositorio = new RepositoryBase<Usuario>(new DAL.Contexto());
            List<Usuario> lista = repositorio.GetList(x => true);
            foreach(var item in lista)
            {
                if(usuario==item.Cuenta && clave==item.Clave)
                {
                    new PanelPrincipal().Show();
                    Program.usuario = item;
                    this.Visible = false;
                    MessageBox.Show("Bienbenido ", item.Cuenta);
                }
                else
                {
                    MessageBox.Show("usuario o password incorrectos ");
                }
            }
            
   
           
            
        }
    }
}
