using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PrestationService.Models
{
    public class bdServiceContext:DbContext
    {
        public bdServiceContext():base("ConnService")
            {
            }
              //public DbSet<Utilisateur>Utilisateur{get;set;}
              public DbSet<Categorie> categories {get;set;}
              public DbSet<SousCategorie> SousCategories {get;set;}
              public DbSet<Personne> personnes {get;set;}
              public DbSet<Role> roles {get;set;}
              public DbSet<Client> clients {get;set;}
              public DbSet<Professionnel> professionnels {get;set;}
              public DbSet<Paiement> paiements {get;set;}
              public DbSet<ChatRoom> chatRooms {get;set;}
              public DbSet<Facture> factures {get;set;}
              public DbSet<Message> messages {get;set;}
              public DbSet<Prestation> prestations {get;set;}
              public DbSet<Service> services {get;set;}
              public DbSet<UserConnect> userConnects {get;set;}


              protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // Configuration.LazyLoadingEnabled = false;

            modelBuilder.Entity<Service>()
               .HasRequired(a => a.Professionnel)
               .WithMany()
               .HasForeignKey(u => u.IdProfessionnel).WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }


    
    }
}