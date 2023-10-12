using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace w16_1.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Pizze> Pizze { get; set; }
        public virtual DbSet<PizzeScelte> PizzeScelte { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Ordini)
                .WithOptional(e => e.Clienti)
                .HasForeignKey(e => e.IdClienti);

            modelBuilder.Entity<Pizze>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizze>()
                .HasMany(e => e.PizzeScelte)
                .WithOptional(e => e.Pizze)
                .HasForeignKey(e => e.PizzaScelta);
        }
    }
}
