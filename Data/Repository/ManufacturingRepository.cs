

namespace covid19.Data
{
    public class ManufacturingRepository: GenericRepository<Manufacturing>, IManufacturingRepository
    {
        public ManufacturingRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}