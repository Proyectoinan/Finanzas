using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Finanzas.Models
{
    public class prestamos
    {
        public int ContactId { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public Double Credito { get; set; }
        public string Metodo_credito { get; set; }
        

        public ContactStatus Status { get; set; }
    }
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}