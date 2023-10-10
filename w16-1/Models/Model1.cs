using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace w16_1.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBcontext")
        {
        }

        public virtual DbSet<Aggiunte> Aggiunte { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Pizze> Pizze { get; set; }
        public virtual DbSet<PizzeScelte> PizzeScelte { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aggiunte>()
                .HasOptional(e => e.Ordini)
                .WithRequired(e => e.Aggiunte);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Ordini)
                .WithOptional(e => e.Clienti)
                .HasForeignKey(e => e.IdClienti);

            modelBuilder.Entity<Pizze>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizze>()
                .HasMany(e => e.Aggiunte)
                .WithOptional(e => e.Pizze)
                .HasForeignKey(e => e.Pizza);

            modelBuilder.Entity<Pizze>()
                .HasMany(e => e.PizzeScelte)
                .WithOptional(e => e.Pizze)
                .HasForeignKey(e => e.PizzaScelta);

            modelBuilder.Entity<PizzeScelte>()
                .HasOptional(e => e.Ordini)
                .WithRequired(e => e.PizzeScelte);

            modelBuilder.Entity<Utenti>()
                .Property(e => e.Ruolo)
                .IsFixedLength();
        }
    }
}
