using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public int idCliente { get; set; }
        public int total { get; set; }

        public Pedido() { }
    }
}
