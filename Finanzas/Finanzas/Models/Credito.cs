using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finanzas.Models
{
    public class Credito
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public float Monto { get; set; }
        public int Plazo { get; set; }
 
    }
}