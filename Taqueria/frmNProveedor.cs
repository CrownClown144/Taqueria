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
    public partial class frmNProveedor : Form
    {
        private ProveedorBLL proveedorBLL = ProveedorBLL.Instance();
        public frmNProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                frmProveedor p = new frmProveedor();
                p.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres cancelar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        frmProveedor p = new frmProveedor();
                        p.Show();
                        this.Hide();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes llenar el campo primero!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Text = "";
                txtNombre.Focus();
            }
            else
            {
                if (proveedorBLL.Add(new BOL.Proveedor()
                {
                    nombre = txtNombre.Text
                }))
                {
                    MessageBox.Show("Proveedor ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmProveedor p = new frmProveedor();
                    p.Show();
                    this.Hide();
                }
            }
        }
    }
}
