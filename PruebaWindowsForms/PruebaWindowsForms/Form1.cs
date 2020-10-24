using PruebaWindowsForms.DataRead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaWindowsForms
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtDireccion.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            btnSave.Visible = true;
            dgvDatos.Enabled = false;
        }

        private void Refresh() {
            if (Operations.Read().Count == 0)
            {
                txtNombre.Text = null;
                txtApellido.Text = null;
                txtID.Text = null;
                txtDireccion.Text = null;
            }
            dgvDatos.DataSource = Operations.Read();
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    Operations.Insert(txtNombre.Text, txtApellido.Text, txtDireccion.Text);
                    btnModificar.Enabled = false;

                }
                else {
                    Operations.Update(Convert.ToInt32(txtID.Text),txtNombre.Text,txtApellido.Text,txtDireccion.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo Actualizar la informacion, Por favor verifique que todos los campos esten diligenciados");
            }
            finally {
                dgvDatos.Enabled = true;
                txtDireccion.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                Refresh();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtDireccion.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled =true;
            btnSave.Visible = true;
            dgvDatos.Enabled = false;
            btnModificar.Enabled= false;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            try
            {
                txtID.Text = dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtApellido.Text = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDireccion.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay registros");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    Operations.Delete(Convert.ToInt32(txtID.Text));
                    btnModificar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione el campo a eliminar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El registro no existe");
            }
            finally {
                Refresh();
            }
        }
    }
}
