using Proyecto_final_de_Facturacion.UI.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final_de_Facturacion.UI
{
    public partial class PanelPrincipal : Form
    {
        public PanelPrincipal()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDeUsuarios usuario = new RegistroDeUsuarios();
            usuario.Show();
            usuario.MdiParent = this;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDeClientes registroDeClientes = new RegistroDeClientes();
            registroDeClientes.Show();
            registroDeClientes.MdiParent = this;
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDeArticulos registroDeArticulos = new RegistroDeArticulos();
            registroDeArticulos.Show();
            registroDeArticulos.MdiParent = this;
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaArticulos consulta = new ConsultaArticulos();
            consulta.Show();
            consulta.MdiParent = this;
        }
    }
}
