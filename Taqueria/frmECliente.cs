using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taqueria
{
    public partial class frmECliente : Form
    {
        private ClienteBLL clienteBLL = ClienteBLL.Instance();
        public string datoObtenido;
        public frmECliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debes llenar los campo primero!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
            else
            {
                if (clienteBLL.Update(new BOL.Cliente()
                {
                    idCliente = Int32.Parse(datoObtenido),
                    nombre = txtNombre.Text,
                    direccion = txtDireccion.Text,
                    telefono = txtTelefono.Text
                }))
                {
                    MessageBox.Show("Cliente editado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCliente c = new frmCliente();
                    c.Show();
                    this.Hide();
                }
            }
        }

        private void frmECliente_Load(object sender, EventArgs e)
        {
            lblDato.Text = "Editando: " + datoObtenido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                frmCliente c = new frmCliente();
                c.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres cancelar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        frmCliente c = new frmCliente();
                        c.Show();
                        this.Hide();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
        }
    }
}
