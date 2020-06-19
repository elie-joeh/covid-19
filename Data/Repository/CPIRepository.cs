

namespace covid19.Data
{
    public class CPIRepository : GenericRepository<CPI>, ICPIRepository
    {
        public CPIRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}