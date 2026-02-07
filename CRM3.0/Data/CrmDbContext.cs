using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CRM.Datenmodelle;

namespace CRM.Data
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Unternehmen> Unternehmen { get; set; }
        public DbSet<Versicherter> Versicherte { get; set; }

        public CrmDbContext()
        {
            Database.Migrate(); // Erstellt DB automatisch beim Start
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crm.db");
        }
    }
}