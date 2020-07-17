using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;


namespace covid19.Data
{
    public class RetailService : IRetailService
    {
        private readonly IRetailRepository _repository;
        public RetailService(IRetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Retail>> GetRetailByVector(string vector)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Retail));

            MemberExpression memberExpression = Expression.Property(parameter, "vector_id");
            Expression right = Expression.Constant(vector);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<Retail, bool>> predicate = Expression.Lambda<Func<Retail, bool>>(predicateBody, parameter);

            return await _repository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Retail>> GetRetailByVectors(string vectors)
        {
            string[] vector_ids_str = vectors.Split(',');
            ParameterExpression parameter = Expression.Parameter(typeof(Retail));
            MemberExpression memberExpression = Expression.Property(parameter, "vector_id");
            Expression right = Expression.Constant(vector_ids_str[0]);
            Expression predicateBody = Expression.Equal(right, memberExpression);            

            for(var i=1; i<vector_ids_str.Count(); i++)
            {
                memberExpression = Expression.Property(parameter, "vector_id");
                right = Expression.Constant(vector_ids_str[i]);
                Expression expression = Expression.Equal(memberExpression, right);

                predicateBody = Expression.OrElse(expression, predicateBody);
            }

            Expression<Func<Retail, bool>> predicate = Expression.Lambda<Func<Retail, bool>>(predicateBody, parameter);

            return await _repository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Retail>> GetRetails()
        {
            return await _repository.GetAllAsyn();
        }
    }
}