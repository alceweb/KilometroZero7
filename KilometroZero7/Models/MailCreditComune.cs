using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KilometroZero7.Models
{
    public class MailCreditComune
    {
        [Required, Display(Name = "Nome Cognome")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Telefono")]
        public string FromTel { get; set; }
        [Required, Display(Name = "Provincia")]
        public string FromPro { get; set; }
        [Required, Display(Name = "Indirizzo municipio")]
        public string FromIndirizzo { get; set; }
        [Required, Display(Name = "CAP")]
        public string FromCap { get; set; }
        [Required, Display(Name = "Comune")]
        public string FromComune { get; set; }

    }
}