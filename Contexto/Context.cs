namespace Contexto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Combustivel> Combustivel { get; set; }
        public virtual DbSet<PostoCombustivel> PostoCombustivel { get; set; }
        public virtual DbSet<Posto> Posto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combustivel>()
                .HasMany(e => e.PostoCombustivel)
                .WithRequired(e => e.Combustivel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Posto>()
                .HasMany(e => e.PostoCombustivel)
                .WithRequired(e => e.Posto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostoCombustivel>().Property(e => e.Preco).HasPrecision(18, 4);

            modelBuilder.Entity<Posto>().Property(e => e.Latitude).HasPrecision(20, 15);
            modelBuilder.Entity<Posto>().Property(e => e.Longitude).HasPrecision(20, 15);
        }
    }
}
