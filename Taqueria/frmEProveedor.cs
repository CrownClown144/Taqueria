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
    public partial class frmEProveedor : Form
    {
        private ProveedorBLL proveedorBLL = ProveedorBLL.Instance();
        public string datoObtenido;
        public int idObtenido;
        public frmEProveedor()
        {
            InitializeComponent();
        }

        private void frmEProveedor_Load(object sender, EventArgs e)
        {
            lblDato.Text = "Editando: " + idObtenido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes llenar el campo primero!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Text = "";
                txtNombre.Focus();
            }
            else
            {
                if (proveedorBLL.Update(new BOL.Proveedor()
                {
                    idProveedor = idObtenido,
                    nombre = txtNombre.Text
                }))
                {
                    MessageBox.Show("Proveedor editado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmProveedor P = new frmProveedor();
                    P.Show();
                    this.Hide();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                frmProveedor P = new frmProveedor();
                P.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres cancelar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        frmProveedor P = new frmProveedor();
                        P.Show();
                        this.Hide();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
        }
    }
}
