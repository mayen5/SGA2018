using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjemploEEF1.Model
{
    public class Bitacora
    {
        [Key]
        public int IdTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; }
        public string Usuario { get; set; }
        public string Terminal { get; set; }
        public string DireccionIp { get; set; }
        public string Descripcion { get; set; }

    }
}
