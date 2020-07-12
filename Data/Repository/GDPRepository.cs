
namespace covid19.Data
{
    public class GDPRepository : GenericRepository<GDP>, IGDPRepository
    {
        public GDPRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}