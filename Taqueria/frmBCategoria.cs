using BLL;
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
    public partial class frmBCategoria : Form
    {
        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        public frmBCategoria()
        {
            InitializeComponent();
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvCategoria.DataSource = categoriaBLL.GetByType(new BOL.Categoria()
            {
                Tipo = txtTipo.Text
            });
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTipo.Text))
            {
                frmCategorias c = new frmCategorias();
                c.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres regresar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        frmCategorias c = new frmCategorias();
                        c.Show();
                        this.Hide();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar una categoria!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmECategoria p = new frmECategoria();
                p.datoObtenido = dgvCategoria.CurrentCell.Value.ToString();
                p.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar una categoria!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres eliminar este elemento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (categoriaBLL.Delete(new BOL.Categoria()
                        {
                            idCategoria = Int32.Parse(dgvCategoria.CurrentCell.Value.ToString())
                        }))
                        {
                            MessageBox.Show("Categoria eliminada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCategoria.DataSource = categoriaBLL.GetByType(new BOL.Categoria()
                            {
                                Tipo = txtTipo.Text
                            });
                            dgvCategoria.ClearSelection();
                        }
                        break;
                    case DialogResult.No:
                        dgvCategoria.ClearSelection();
                        break;
                }

            }
        }
    }
}
