using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KilometroZero7.Models
{
    public class Comuni
    {
        [Key]
        public int ComuneId { get; set; }
        public string NomeRiferimento { get; set; }
        public string TelRiferimento { get; set; }
        public string Comune { get; set; }
        public string Provincia { get;set;}
        public string Regione { get; set; }

    }
}