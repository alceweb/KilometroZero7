using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KilometroZero7.Models
{
    // È possibile aggiungere dati di profilo dell'utente specificando altre proprietà della classe ApplicationUser. Per ulteriori informazioni, visitare http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

    public class Comuni
    {
        [Key]
        public int comune_Id { get; set; }
        public string nome_comune { get; set; }
        public string provincia { get; set; }
        public string regione { get; set; }
        public DateTime data_registrazione { get; set; }
        public bool attivo { get; set; }
        public DateTime ultimo_accesso { get; set; }
    }
    public class Prodotti
    {
        [Key]
        public int prodottoId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool attivo { get; set; }
        public string nome_prodotto { get; set; }
        public string descrizione_prodotto { get; set; }
        public decimal prezzo_prodotto { get; set; }
        public int? categoria_Id { get; set; }
        public virtual Categorie nome_categoria { get; set; }
        public DateTime dataInizio { get; set; }
        public DateTime dataFine { get; set; }
    }

    public class Categorie
    {
        [Key]
        public int categoria_id { get; set; }
        public string nome_categoria { get; set; }
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
        public DbSet<Prodotti> Prodottis { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Comuni> Comunis { get; set; }

        public System.Data.Entity.DbSet<KilometroZero7.Models.EditUserViewModel> EditUserViewModels { get; set; }
    }
}