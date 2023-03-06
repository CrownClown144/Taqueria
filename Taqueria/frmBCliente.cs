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
    public partial class frmBCliente : Form
    {
        private ClienteBLL clienteBLL = ClienteBLL.Instance();
        public frmBCliente()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            dgvCliente.DataSource = clienteBLL.GetByName(new BOL.Cliente()
            {
                nombre = txtNombre.Text
            });
        }
    }
}
