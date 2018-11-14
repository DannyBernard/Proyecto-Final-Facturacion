﻿using Proyecto_final_de_Facturacion.BLL;
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

namespace Proyecto_final_de_Facturacion.UI
{
    public partial class RegistroDeUsuarios : Form
    {
        RepositoryBase<Usuario> repository;
        public RegistroDeUsuarios()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            UsuariotextBox.Text = string.Empty;
            PassawordtextBox.Text = string.Empty;
            NombretextBox.Text = string.Empty;
            PosicionnumericUpDown.Value = 0;
        }
        public Usuario LlenarClase()
        {
            Usuario usuario = new Usuario();
            usuario.IDUsuario = Convert.ToInt32(IDnumericUpDown);
            usuario.Cuenta = UsuariotextBox.Text;
            usuario.Clave = PassawordtextBox.Text;
            usuario.Nombre = NombretextBox.Text;
            usuario.Pocision = Convert.ToBoolean(PosicionnumericUpDown.Value);
            return usuario;
        }
        public void LlenarCampo(Usuario usuario)
        {
            IDnumericUpDown.Value = usuario.IDUsuario;
            UsuariotextBox.Text = usuario.Cuenta;
            PassawordtextBox.Text = usuario.Clave;
            NombretextBox.Text = usuario.Nombre;
            PosicionnumericUpDown.Value =Convert.ToInt32( usuario.Pocision);
        }

        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(UsuariotextBox.Text))
            {
                errorProvider1.SetError(UsuariotextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(PassawordtextBox.Text))
            {
                errorProvider1.SetError(PassawordtextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Campo Vacio");
                paso = false;
            }
            if(PosicionnumericUpDown.Value < 0 && PosicionnumericUpDown.Value > 1)
            {
                errorProvider1.SetError(IDnumericUpDown, "El valor Debe ser 0 o 1");
                paso = false;
            }
            return paso;
        }
        public bool ExiteEnLaDb()
        {
            repository = new RepositoryBase<Usuario>();
            Usuario usuario = repository.Buscar((int)IDnumericUpDown.Value);
            return (usuario != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            repository = new RepositoryBase<Usuario>();
            bool paso = false;
            Usuario usuario;
            if (!Validar())
                return;
            usuario = LlenarClase();
            if (IDnumericUpDown.Value == 0)
            {
                paso = repository.Guardar(usuario);
            }
            else
            {
                if (!ExiteEnLaDb())
                {
                    MessageBox.Show("No Se Puede Modificar No Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repository.Modificar(usuario);
            }
            if (paso)
            {
                MessageBox.Show("Guardado con Exito", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Se Puede Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            repository = new RepositoryBase<Usuario>();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            if (!ExiteEnLaDb())
            {
                errorProvider1.SetError(IDnumericUpDown, "Este Usuario No Exite");
                IDnumericUpDown.Focus();
                return;
            }
            if (repository.Eliminar(id))
            {
                MessageBox.Show("Usuario Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se Pudo Eliminar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            repository = new RepositoryBase<Usuario>();
            int id;
            Usuario usuario = new Usuario();

            int.TryParse(IDnumericUpDown.Text, out id);
            usuario = repository.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Usuario Econtrado","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LlenarCampo(usuario);
            }
            else
            {
                MessageBox.Show("Usuario no Exite","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
