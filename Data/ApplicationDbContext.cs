using Microsoft.EntityFrameworkCore;
using covid19.Data;

namespace covid19.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext () : base()
        {
        }

        public ApplicationDbContext (DbContextOptions options) : base(options)
        {
        }
        #endregion Constructor


        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map Entity names to DB Table names
            modelBuilder.Entity<Geography>().ToTable("Geography");
            modelBuilder.Entity<CPI>().ToTable("CPI");
            modelBuilder.Entity<Employment>().ToTable("Employment");
        }
        #endregion Methods


        #region Properties
        public DbSet<Geography> Geographies {get; set;}
        public DbSet<CPI> CPIs {get; set;}
        public DbSet<Employment> Employments {get; set;}
        #endregion Properties
    }
}