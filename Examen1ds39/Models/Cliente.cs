using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen1ds39.Models
{
    public class Cliente
    {
        public int cod_cliente { get; set; }
        [Required]
        [MaxLength(30)]
        public string nombres { get; set; }
        [Required]
        [MaxLength(30)]
        public string apellidos { get; set; }
        [Required]
        [MaxLength(10)]
        public string dui { get; set; }
        [Required]
        [MaxLength(100)]
        public string direccion { get; set; }
        [Required]
        [MaxLength(17)]
        public string nit { get; set; }
    }
}