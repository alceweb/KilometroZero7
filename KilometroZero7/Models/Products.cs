using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KilometroZero7.Models
{
    public class Products
    {
    }
    public class Prodotti
    {
        [Key]
        public int prodotto_id { get; set; }
        public string utente { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool attivo { get; set; }
        public string nome_prodotto { get; set; }
        public string descrizione_prodotto { get; set; }
        public decimal prezzo_prodotto { get; set; }
        public int categoria_Id { get; set; }
        public virtual Categorie nome_categoria { get; set; }
    }

    public class Categorie
    {
        [Key]
        public int categoria_id { get; set; }
        public string nome_categoria { get; set; }
    }
}