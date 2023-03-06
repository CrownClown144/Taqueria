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
    public partial class frmIProveedores : Form
    {
        private ProveedorBLL proveedorBLL = ProveedorBLL.Instance();
        public frmIProveedores()
        {
            InitializeComponent();
        }

        private void frmIProveedores_Load(object sender, EventArgs e)
        {
            dgvProveedoresInactivos.DataSource = proveedorBLL.GetOnlySupplierInactive();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvProveedoresInactivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un proveedor!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres restaurar este elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (proveedorBLL.Restore(new BOL.Proveedor()
                        {
                            idProveedor = Int32.Parse(dgvProveedoresInactivos.CurrentCell.Value.ToString())
                        }))
                        {
                            MessageBox.Show("Proveedor restaurado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvProveedoresInactivos.DataSource = proveedorBLL.GetOnlySupplierInactive();
                            dgvProveedoresInactivos.ClearSelection();
                        }
                        break;
                    case DialogResult.No:
                        dgvProveedoresInactivos.ClearSelection();
                        break;
                }

            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmProveedor p = new frmProveedor();
            p.Show();
            this.Hide();
        }
    }
}
