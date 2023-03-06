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
    public partial class frmProveedor : Form
    {
        private ProveedorBLL proveedorBLL = ProveedorBLL.Instance();
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNProveedor np = new frmNProveedor();
            np.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un proveedor!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmEProveedor ep = new frmEProveedor();
                ep.datoObtenido = dgvProveedores.CurrentCell.Value.ToString();
                ep.idObtenido = proveedorBLL.GetIdByName(new BOL.Proveedor()
                {
                    nombre = dgvProveedores.CurrentCell.Value.ToString()
                }).idProveedor;

                ep.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = proveedorBLL.GetIdByName(new BOL.Proveedor()
            {
                nombre = dgvProveedores.CurrentCell.Value.ToString()
            }).idProveedor;

            if (dgvProveedores.SelectedRows.Count == 0)
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
                            idProveedor = Id
                        }))
                        {
                            MessageBox.Show("Proveedor eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                        break;
                    case DialogResult.No:
                        dgvProveedores.ClearSelection();
                        break;
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBProveedor bp = new frmBProveedor();
            bp.Show();
            this.Hide();
        }

        private void tsbtnRegresar_Click(object sender, EventArgs e)
        {
            frmPricipal inicio = new frmPricipal();
            inicio.Show();
            this.Hide();
        }

        private void tsbtnInactivos_Click(object sender, EventArgs e)
        {
            frmIProveedores ip = new frmIProveedores();
            ip.Show();
            this.Hide();
        }
        void CargarDatos()
        {
            dgvProveedores.DataSource = proveedorBLL.GetOnlySupplierActive();
            dgvProveedores.Columns["idProveedor"].Visible = false;
            dgvProveedores.Columns["Activo"].Visible = false;
            dgvProveedores.ClearSelection();
        }
    }
}
