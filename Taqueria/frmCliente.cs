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
    public partial class frmCliente : Form
    {
        private ClienteBLL clienteBLL = ClienteBLL.Instance();
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            GenerarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNCliente nc = new frmNCliente();
            nc.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un cliente!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmECliente ec = new frmECliente();
                ec.datoObtenido = dgvClientes.CurrentCell.Value.ToString();
                ec.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un cliente!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres eliminar este elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (clienteBLL.Delete(new BOL.Cliente()
                        {
                            idCliente = Int32.Parse(dgvClientes.CurrentCell.Value.ToString())
                        }))
                        {
                            MessageBox.Show("Cliente eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GenerarDatos();
                            
                        }
                        break;
                    case DialogResult.No:
                        dgvClientes.ClearSelection();
                        break;
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBCliente bc = new frmBCliente();
            bc.Show();
            this.Hide();
        }

        private void tsbtnRegresar_Click(object sender, EventArgs e)
        {
            frmPricipal p = new frmPricipal();
            p.Show();
            this.Hide();
        }

        void GenerarDatos()
        {
            dgvClientes.DataSource = clienteBLL.GetALL();
            dgvClientes.Columns["idCliente"].Visible = false;
            dgvClientes.ClearSelection();
        }

    }
}
