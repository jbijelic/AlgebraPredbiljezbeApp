using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlgebraPredbiljezbeApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Predbiljezba> Predbiljezba { get; set; }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
