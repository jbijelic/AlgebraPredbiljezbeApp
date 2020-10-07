using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlgebraPredbiljezbeApp.Data
{
    public partial class aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext : DbContext
    {
        public aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext()
        {
        }

        public aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext(DbContextOptions<aspnetAlgebraPredbiljezbeAppD8A763C64D0E4A4EBB4118DBF6243A5DContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Predbiljezba> Predbiljezba { get; set; }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-AlgebraPredbiljezbeApp-D8A763C6-4D0E-4A4E-BB41-18DBF6243A5D;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Predbiljezba>(entity =>
            {
                entity.ToTable("predbiljezba");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(50);

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(50);

                entity.Property(e => e.SeminarId).HasColumnName("seminar_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Seminar)
                    .WithMany(p => p.Predbiljezba)
                    .HasForeignKey(d => d.SeminarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_predbiljezba_seminar");
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.ToTable("seminar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(100);

                entity.Property(e => e.Popunjen).HasColumnName("popunjen");
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.ToTable("zaposlenik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
