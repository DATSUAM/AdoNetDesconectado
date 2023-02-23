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

namespace AdoNetDesconectado
{
    public partial class frmTipoCliente : Form
    {
        string cadenaConexion = @"Server=localhost\SQLEXPRESS; DataBase=BancoBD; Integrated Security=true";
        SqlDataAdapter adaptador;
        SqlConnection conexion;
        DataSet datos;
        public frmTipoCliente()
        {
            InitializeComponent();

            //Creamos la instancia de la Conexion
            conexion = new SqlConnection(cadenaConexion);

            // Creamos la instancia del Adaptador
            adaptador = new SqlDataAdapter();

            //Crear la instancia del DataSet
            datos = new DataSet();

            // Configuramos métodos del Adaptador
            adaptador.SelectCommand = new SqlCommand("SELECT * FROM TipoCliente", conexion);
        }

        private void cargarFormulario(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            // Llenar Datos al DataSet (DataTable TipoCliente)
            adaptador.Fill(datos, "TipoCliente");

            //Enlazar datos al DataGidView
            dgvDatos.DataSource = datos.Tables["TipoCliente"];
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var frm = new frmTipoClienteEdit();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Presionaste OK");
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            var filaActual = dgvDatos.CurrentRow;
            if (filaActual != null)
            {
                var ID = filaActual.Cells[0].Value.ToString();
            }
            DataRow fila = datos.Tables["TipoCliente"].Select($"ID={"ID"}").FirstOrDefault();
            
            var frm = new frmTipoClienteEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Presionaste OK");
            }
        }
    }
}
