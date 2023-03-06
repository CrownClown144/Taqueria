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
    public partial class frmCategorias : Form
    {
        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = categoriaBLL.GetOnlyCategoryActive();
            dgvCategorias.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNCategoria p = new frmNCategoria();
            p.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dgvCategorias.SelectedRows.Count == 0) {
                MessageBox.Show("Debes seleccionar una categoria!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmECategoria p = new frmECategoria();
                p.datoObtenido = dgvCategorias.CurrentCell.Value.ToString();
                p.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
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
                            idCategoria = Int32.Parse(dgvCategorias.CurrentCell.Value.ToString())
                }))
                        {
                            MessageBox.Show("Categoria eliminada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCategorias.DataSource = categoriaBLL.GetOnlyCategoryActive();
                            dgvCategorias.ClearSelection();
                        }
                        break;
                    case DialogResult.No:
                        dgvCategorias.ClearSelection();
                    break;
                }
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBCategoria bc = new frmBCategoria();
           
            bc.Show();
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
            frmICategorias ic = new frmICategorias();
            ic.Show();
            this.Hide();
        }
    }
}
