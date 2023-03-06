using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Detalle_Pedido
    {
        public int idDetalle { get; set; }

        public int idBebida { get; set; }

        public int idCarne { get; set; }

        public int CantidadB { get; set; }

        public int CantidadC { get; set; }

        public int idMenu { get; set; }

        public int subTotal { get; set; }

        public Detalle_Pedido() { }
    }
}
