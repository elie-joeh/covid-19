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
            modelBuilder.Entity<GDP>().ToTable("GDP");
            modelBuilder.Entity<GDP>().HasKey(x => new {x.Vector_id, x.Reference_date});
            modelBuilder.Entity<Retail>().ToTable("Retail");
            modelBuilder.Entity<Manufacturing>().ToTable("Manufacturing");
            modelBuilder.Entity<Debt>().ToTable("Canada_Debt");
            modelBuilder.Entity<Debt>().HasKey(x => new {x.Vector_id, x.Reference_date});
        }
        #endregion Methods


        #region Properties
        public DbSet<Geography> Geographies {get; set;}
        public DbSet<CPI> CPIs {get; set;}
        public DbSet<Employment> Employments {get; set;}
        public DbSet<GDP> GDPs {get; set;}
        public DbSet<Retail> Retails {get; set;}
        public DbSet<Manufacturing> Manufacturings {get; set;}
        public DbSet<Debt> Debts {get; set;}
        #endregion Properties
    }
}