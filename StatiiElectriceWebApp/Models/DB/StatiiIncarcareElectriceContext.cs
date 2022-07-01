using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class StatiiIncarcareElectriceContext : DbContext
    {
        public StatiiIncarcareElectriceContext()
        {
        }

        public StatiiIncarcareElectriceContext(DbContextOptions<StatiiIncarcareElectriceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prize> Prizes { get; set; } = null!;
        public virtual DbSet<Rezervari> Rezervaris { get; set; } = null!;
        public virtual DbSet<Statii> Statiis { get; set; } = null!;
        public virtual DbSet<Tip> Tips { get; set; } = null!;
        public virtual DbSet<Useri> Useris { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-M1AENST\\SQLEXPRESS;Initial Catalog=StatiiIncarcareElectrice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prize>(entity =>
            {
                entity.ToTable("Prize");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StatieId).HasColumnName("Statie_ID");

                entity.Property(e => e.TipId).HasColumnName("Tip_ID");

                entity.HasOne(d => d.Statie)
                    .WithMany(p => p.Prizes)
                    .HasForeignKey(d => d.StatieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plug_Station");

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.Prizes)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plug_Type");
            });

            modelBuilder.Entity<Rezervari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Rezervari");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.NrMasina).HasMaxLength(50);

                entity.Property(e => e.PrizaId).HasColumnName("PrizaID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Priza)
                    .WithMany()
                    .HasForeignKey(d => d.PrizaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervari_Prize1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Rezervari_Useri");
            });

            modelBuilder.Entity<Statii>(entity =>
            {
                entity.ToTable("Statii");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nume");

                entity.Property(e => e.Oras)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("oras");
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.ToTable("Tip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nume");
            });

            modelBuilder.Entity<Useri>(entity =>
            {
                entity.ToTable("Useri");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Parola)
                    .HasMaxLength(50)
                    .HasColumnName("parola");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
