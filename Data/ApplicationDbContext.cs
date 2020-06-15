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
            modelBuilder.Entity<Province>().ToTable("Provinces");
        }
        #endregion Methods


        #region Properties
        public DbSet<Province> Provinces {get; set;}
        #endregion Properties
    }
}