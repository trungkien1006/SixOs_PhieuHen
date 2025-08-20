using SixOs_Test_2.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SixOs_Test_2.Models.M0402.E0402;
using SixOs_Test_2.Models.M0402.DTO0402;

namespace SixOs_Test_2.Context
{
    public class Context0402 : DbContext
    {
        public Context0402(DbContextOptions<Context0402> options) : base(options) { }

        public DbSet<M0402NoiDungHen> DSNoiDungHen { get; set; }
        public DbSet<DTO0402DataPDFPhieuHen> DataPhieuHen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M0402NoiDungHen>().ToTable("Ql_NoiDungHen");
            modelBuilder.Entity<DTO0402DataPDFPhieuHen>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
