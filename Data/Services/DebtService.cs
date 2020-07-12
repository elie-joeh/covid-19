using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public class DebtService: IDebtService
    {
        private readonly IDebtReposiroty _debtRepo;

        public DebtService(IDebtReposiroty debtRepo)
        {
            _debtRepo = debtRepo;
        }

        public async Task<IEnumerable<Debt>> GetDebts()
        {
            return await _debtRepo.GetAllAsyn();
        }

        public async Task<IEnumerable<Debt>> GetDebtsByVector(string vector_id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Debt));

            MemberExpression memberExpression = Expression.Property(parameter, "Vector_id");
            Expression right = Expression.Constant(vector_id);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<Debt, bool>> predicate = Expression.Lambda<Func<Debt, bool>>(predicateBody, parameter);

            return await _debtRepo.FindByAsyn(predicate); 
        }

        public async Task<IEnumerable<Debt>> GetDebtsByVectors(string vector_ids)
        {
            string[] vector_ids_str = vector_ids.Split(',');

            ParameterExpression parameter = Expression.Parameter(typeof(Debt));
            MemberExpression memberExpression = Expression.Property(parameter, "Vector_id");
            Expression right = Expression.Constant(vector_ids_str[0]);
            Expression predicateBody = Expression.Equal(right, memberExpression);            

            for(var i=1; i<vector_ids_str.Count(); i++)
            {
                memberExpression = Expression.Property(parameter, "Vector_id");
                right = Expression.Constant(vector_ids_str[i]);
                Expression expression = Expression.Equal(memberExpression, right);

                predicateBody = Expression.OrElse(expression, predicateBody);
            }

            Expression<Func<Debt, bool>> predicate = Expression.Lambda<Func<Debt, bool>>(predicateBody, parameter);

            return await _debtRepo.FindByAsyn(predicate);
        }
    }
}