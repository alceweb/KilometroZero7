using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KilometroZero7.Models
{
    public class EmailFormModel 
    {
        [Required, Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required, Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Required, Display(Name = "Mail"), EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }
        [Required, Display(Name = "CAP")]
        public string CAP { get; set; }
        [Required, Display(Name = "Città")]
        public string City { get; set; }
        [Required, Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Required, Display(Name = "Ragione sociale")]
        public string RagioneSociale { get; set; }
        [Required, Display(Name = "Partita Iva")]
        public string PartitaIva { get; set; }
        public string Message { get; set; }
    }
}