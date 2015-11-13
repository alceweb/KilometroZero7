using System.Data.Entity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace KilometroZero7.Models
{
    // È possibile aggiungere dati di profilo dell'utente specificando altre proprietà della classe ApplicationUser. Per ulteriori informazioni, visitare http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string RagioneSociale { get; set; }
        public string PartitaIva { get; set; }
        public string Telefono { get; set; }
        public string Indirizzo { get; set; }
        public string CAP { get; set; }
        public int? ComuneId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

        public class Prodotti
    {
        [Key]
        public int prodotto_id { get; set; }
        public virtual ApplicationUser utente { get; set; }
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
    public class Comuni
    {
        [Key]
        public int ComuneId { get; set; }
        public string NomeRiferimento { get; set; }
        public string TelRiferimento { get; set; }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<KilometroZero7.Models.Prodotti> Prodottis { get; set; }

        public System.Data.Entity.DbSet<KilometroZero7.Models.Categorie> Categories { get; set; }

        public System.Data.Entity.DbSet<KilometroZero7.Models.Comuni> Comunis { get; set; }
    }
}