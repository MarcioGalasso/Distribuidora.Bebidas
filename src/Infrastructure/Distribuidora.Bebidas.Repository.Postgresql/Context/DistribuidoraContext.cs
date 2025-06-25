using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Distribuidora.Bebidas.Repository.Postgresql.Configuration;

namespace Distribuidora.Bebidas.Repository.Postgresql.Context
{
    public class DistribuidoraContext : DbContext
    {
        public DistribuidoraContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.LogTo(message => Debug.WriteLine(message));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DistribuidoraContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
