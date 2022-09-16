using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp1.Models
{
    public class Kunder
    {
        public int id { get; set; }
        public string fornavn { get; set; }

        public string etternavn { get; set; }

        public string adresse { get; set; }

        virtual public Poststeder poststed { get; set; }

    }

    public class Poststeder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string postnr { get; set; }
        public string poststed { get; set; }
    }
    public class KundeDB : DbContext
    {
        public KundeDB (DbContextOptions<KundeDB> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Kunder> Kunder { get; set; }

        public DbSet<Poststeder> Poststeder { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
