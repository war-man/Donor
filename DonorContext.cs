using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donor.Entity;

namespace Donor
{
    public class DonorContext : DbContext
    {
        public DonorContext()
        {
        }

        public DonorContext(DbContextOptions<DonorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DonorModel> Donors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonorModel>(entity =>
            {
                entity.ToTable("Donor");
                entity.HasKey(a => a.Id);
            });
            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");
                entity.HasKey(a => a.Id);
            });
        }

        public DbSet<Donor.Entity.Request> Request { get; set; }

    }
}
