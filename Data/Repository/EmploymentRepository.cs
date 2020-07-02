
//add methods here if a change of the generic repo logic needs to be change for this specific class
namespace covid19.Data
{
    public class EmploymenRepository : GenericRepository<Employment>, IEmploymentRepository
    {
        public EmploymenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}