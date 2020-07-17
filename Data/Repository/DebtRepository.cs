

namespace covid19.Data
{
    public class DebtRepository: GenericRepository<Debt>, IDebtRepository
    {
        public DebtRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}