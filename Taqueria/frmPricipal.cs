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
    public partial class frmPricipal : Form
    {
        public frmPricipal()
        {
            InitializeComponent();
        }

        private void carneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarne c = new frmCarne();
            c.Show();
            this.Hide();  
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu m = new frmMenu();
            m.Show();
            this.Hide();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.Show();
            this.Hide();
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor p = new frmProveedor();
            p.Show();
            this.Hide();
        }
    }
}
