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
    public partial class frmECategoria : Form
    {
        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        public string datoObtenido;
        public frmECategoria()
        {
            InitializeComponent();
        }

        private void frmECategoria_Load(object sender, EventArgs e)
        {
            lblDato.Text = "Editando: " + datoObtenido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debes llenar el campo primero!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipo.Text = "";
                txtTipo.Focus();
            }
            else
            {
                if (categoriaBLL.Update(new BOL.Categoria()
                {
                    idCategoria = Int32.Parse(datoObtenido),
                    Tipo = txtTipo.Text
                }))
                {
                    MessageBox.Show("Categoria editada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCategorias c = new frmCategorias();
                    c.Show();
                    this.Hide();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTipo.Text))
            {
                frmCategorias c = new frmCategorias();
                c.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Seguro que quieres cancelar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
    }
}
