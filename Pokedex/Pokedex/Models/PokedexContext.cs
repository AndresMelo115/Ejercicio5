using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pokedex.Models
{
    public partial class PokedexContext : DbContext
    {
        public PokedexContext()
        {
        }

        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=EXT-PC\\SQLEXPRESS;Database=Pokedex;persist security info=True;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasKey(e => e.PokeId)
                    .HasName("PK__Pokemon__8B12910981357BBF");

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Move1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Move2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Move3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Move4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pokemon__Region__34C8D9D1");

                entity.HasOne(d => d.Tipo1Navigation)
                    .WithMany(p => p.PokemonTipo1Navigation)
                    .HasForeignKey(d => d.Tipo1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pokemon__Tipo1__36B12243");

                entity.HasOne(d => d.Tipo2Navigation)
                    .WithMany(p => p.PokemonTipo2Navigation)
                    .HasForeignKey(d => d.Tipo2)
                    .HasConstraintName("FK__Pokemon__Tipo2__37A5467C");
            });

            modelBuilder.Entity<Regiones>(entity =>
            {
                entity.HasKey(e => e.RegId)
                    .HasName("PK__Regiones__2C6822F8D9FEB513");

                entity.Property(e => e.NombreR)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.Property(e => e.NombreT)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
