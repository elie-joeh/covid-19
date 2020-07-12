

namespace covid19.Data
{
    public class DebtRepository: GenericRepository<Debt>, IDebtReposiroty
    {
        public DebtRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}