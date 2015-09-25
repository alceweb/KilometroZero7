using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace KilometroZero7.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Ragione sociale")]
        public string RagioneSociale { get; set; }
        [Display(Name = "Partita IVA")]
        public string PartitaIva { get; set; }
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }
        [Display(Name = "CAP")]
        public string CAP { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
    public class EditCommViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Ragione sociale")]
        public string RagioneSociale { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Partita IVA")]
        public string PartitaIva { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "CAP")]
        public string CAP { get; set; }

    }
}