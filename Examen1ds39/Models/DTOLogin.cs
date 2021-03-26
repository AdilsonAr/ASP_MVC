using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen1ds39.Models
{
    public class DTOLogin
    {
        [Required]
        [MaxLength(30)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(20)]
        public string contra { get; set; }
    }
}