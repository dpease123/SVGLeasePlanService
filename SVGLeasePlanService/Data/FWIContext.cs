namespace SVGLeasePlanService.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FWIContext : DbContext
    {
        public FWIContext()
            : base("name=FWIContext")
        {
        }

        public virtual DbSet<PlayerLogXML> PlayerLogXMLs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerLogXML>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
