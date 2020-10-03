using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public class DebtService: IDebtService
    {
        private readonly IDebtRepository _debtRepo;

        public DebtService(IDebtRepository debtRepo)
        {
            _debtRepo = debtRepo;
        }

        public async Task<IEnumerable<Debt>> GetDebts()
        {
            return await _debtRepo.GetAllAsyn();
        }

        public async Task<IEnumerable<Debt>> GetNetDebt()
        {
            var debtNetVectorId = DataConstants.VectorId.NET_DEBT;
            ParameterExpression parameter = Expression.Parameter(typeof(Debt));
            MemberExpression memberExpression = Expression.Property(parameter, "Vector_id");

            Expression right = Expression.Constant(debtNetVectorId);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<Debt, bool>> predicate = Expression.Lambda<Func<Debt, bool>>(predicateBody, parameter);

            return await _debtRepo.FindByAsyn(predicate); 
        }
    }
}