using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Inventario
    {
        public int idInventario { get; set; }
        public string nombre { get; set; }
        public int idCategoria { get; set; }
        public int idProveedor { get; set; }
        public int cantidad { get; set; }
        public string gramaje { get; set; }
        public DateTime fecha { get; set; }
        public double costo { get; set; }
        public bool Activo { get; set; }

        public Inventario() { }
    }
}
