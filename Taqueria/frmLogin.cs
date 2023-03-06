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
using BLL;

namespace Taqueria
{
    public partial class frmLogin : Form
    {
        public UsuarioBLL usuarioBLL = UsuarioBLL.Instance();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuarioBLL.Login(new BOL.Usuario()
            {
                nombre = txtUsuario.Text,
                contraseña = txtContraseña.Text
            }))
            {
                frmSplash p = new frmSplash();
                p.Show(); 
                this.Hide();
                Clean();

                /*
                MessageBox.Show("Inicio Correcto", Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ;
                */

            }
            else
            {
                MessageBox.Show("Error Inicio", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Clean()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Focus();
        }

    }
}
