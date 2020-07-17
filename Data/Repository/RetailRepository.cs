

namespace covid19.Data
{
    public class RetailRepository : GenericRepository<Retail>, IRetailRepository
    {
        public RetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}