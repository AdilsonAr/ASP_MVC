using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen1ds39.Models
{
    public class Cliente
    {

        public int cod_cliente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public string direccion { get; set; }
        public string nit { get; set; }
    }
}