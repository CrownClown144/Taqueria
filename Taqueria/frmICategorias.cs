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
    public partial class frmICategorias : Form
    {
        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        public frmICategorias()
        {
            InitializeComponent();
        }

        private void frmICategorias_Load(object sender, EventArgs e)
        {
            dgvCategoriasInactivas.DataSource = categoriaBLL.GetOnlyCategorInactive();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvCategoriasInactivas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar una categoria!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres restaurar este elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (categoriaBLL.Restore(new BOL.Categoria()
                        {
                            idCategoria = Int32.Parse(dgvCategoriasInactivas.CurrentCell.Value.ToString())
                        }))
                        {
                            MessageBox.Show("Categoria restaurada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCategoriasInactivas.DataSource = categoriaBLL.GetOnlyCategorInactive();
                            dgvCategoriasInactivas.ClearSelection();
                        }
                        break;
                    case DialogResult.No:
                        dgvCategoriasInactivas.ClearSelection();
                        break;
                }

            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmCategorias c = new frmCategorias();
            c.Show();
            this.Hide();
        }
    }
}
