namespace SVGLeasePlanService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SVGLeasePlanService.Data.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class LDBContext : DbContext
    {
        public LDBContext()
            : base("name=LDBContext")

        {
        }

        public DbSet<BldgScale> BldgScale { get; set; }
        public DbSet<Polygon> Polygon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LDBContext>(null);

            modelBuilder.Entity<BldgScale>()
           .ToTable("tblBldgScale");

            modelBuilder.Entity<Polygon>()
           .ToTable("tblPowerBIPolygons");


            



        }
    }
}
