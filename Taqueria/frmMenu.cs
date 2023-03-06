using BLL;
using BOL;
using Microsoft.SqlServer.Server;
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
    public partial class frmMenu : Form
    {
        public MenuBLL menuBLL = MenuBLL.Instance();

        public frmMenu()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuBLL.Add(new BOL.Menu()
            {
                tipo = txtTipo.Text,
                preciounitario = int.Parse(txtPU.Text)
            }))
            {
                dgvMenu.DataSource = menuBLL.GetAll();
                MessageBox.Show("Categoria ingresada", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
        }

        private void Clean()
        {
            txtID.Text = "";
            txtTipo.Text = "";
            txtPU.Text = "";
            txtID.Focus();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            dgvMenu.DataSource = menuBLL.GetAll();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPricipal p = new frmPricipal();
            p.Show();
            this.Hide();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
                if (menuBLL.Delete(new BOL.Menu()
                {
                    tipo = txtTipo.Text
                }))
                {
                    dgvMenu.DataSource = menuBLL.GetAll();
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

        
    }
}
