using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDesconectado
{
    public partial class frmTipoClienteEdit : Form
    {
        DataRow fila;
        public frmTipoClienteEdit(DataRow filaEditar = null)
        {
            InitializeComponent();
            if(filaEditar != null )
            {
                this.fila = filaEditar;
                this.Text = "Editar registro";
                mostrarDatos();
            } 
        }

        private void aceptarCambios(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Sistemas", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult= DialogResult.OK;
        }

        private void mostrarDatos()
        {
            txtNombre.Text = this.fila["Nombre"].ToString();
        }
    }
}
