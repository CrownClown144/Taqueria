using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using BLL;
namespace Taqueria
{
    public partial class frmCarne : Form
    {
        private CarneBLL carneBLL = CarneBLL.Instance();
        public frmCarne()
        {
            InitializeComponent();
        }

        private void frmCarne_Load(object sender, EventArgs e)
        {
            dgvCarne.DataSource = carneBLL.GetAll();
        }

        private void btnGurdar_Click(object sender, EventArgs e)
        {
            if (carneBLL.Add(new BOL.Carne() {
                nombre = txtnombre.Text
            }))
            {
                dgvCarne.DataSource = carneBLL.GetAll();
                MessageBox.Show("Categoria ingresada", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            } 
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (carneBLL.Delete(new BOL.Carne()
            {
                    nombre = txtnombre.Text
            }))
            {
                dgvCarne.DataSource = carneBLL.GetAll();
                MessageBox.Show("Categoria Borrada", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            else
            {
                MessageBox.Show("Error, Solo Colocar Nombre", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
        }
        private void Clean()
        {
            txtID.Text = "";
            txtnombre.Text = "";
            txtID.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (carneBLL.Update(new BOL.Carne()
            {
                idCarne = Int32.Parse(txtID.Text),
                nombre = txtnombre.Text
            }))
            {
                dgvCarne.DataSource = carneBLL.GetAll();
                MessageBox.Show("Categoria Actualizada", Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPricipal p = new frmPricipal();
            p.Show();
            this.Hide();
        }
    }
}
