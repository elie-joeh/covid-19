using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;


namespace covid19.Data
{
    public class ManufacturingService : IManufacturingService
    {
        private readonly IManufacturingRepository _repository;
        public ManufacturingService(IManufacturingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Manufacturing>> GetManufacturingByVector(string vector)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Manufacturing));

            MemberExpression memberExpression = Expression.Property(parameter, "Vector_id");
            Expression right = Expression.Constant(vector);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<Manufacturing, bool>> predicate = Expression.Lambda<Func<Manufacturing, bool>>(predicateBody, parameter);

            return await _repository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Manufacturing>> GetManufacturingByVectors(string vectors)
        {
            string[] vector_ids_str = vectors.Split(',');
            ParameterExpression parameter = Expression.Parameter(typeof(Manufacturing));
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

            Expression<Func<Manufacturing, bool>> predicate = Expression.Lambda<Func<Manufacturing, bool>>(predicateBody, parameter);

            return await _repository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Manufacturing>> GetManufacturings()
        {
            return await _repository.GetAllAsyn();
        }
    }
}