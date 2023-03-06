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
    public partial class frmBProveedor : Form
    {
        private ProveedorBLL proveedorBLL = ProveedorBLL.Instance();
        public frmBProveedor()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvProveedor.DataSource = proveedorBLL.GetByName(new BOL.Proveedor()
            {
                nombre = txtNombre.Text
            });
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                frmProveedor p = new frmProveedor();
                p.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres regresar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un proveedor!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmEProveedor ep = new frmEProveedor();
                ep.datoObtenido = dgvProveedor.CurrentCell.Value.ToString();
                ep.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un proveedor!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres eliminar este elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (proveedorBLL.Delete(new BOL.Proveedor()
                        {
                            idProveedor = Int32.Parse(dgvProveedor.CurrentCell.Value.ToString())
                        }))
                        {
                            MessageBox.Show("Proveedor eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvProveedor.DataSource = proveedorBLL.GetByName(new BOL.Proveedor()
                            {
                                nombre = txtNombre.Text
                            });
                            dgvProveedor.ClearSelection();
                        }
                        break;
                    case DialogResult.No:
                        dgvProveedor.ClearSelection();
                        break;
                }

            }
        }
    }
}
