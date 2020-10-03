using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public class GDPService : IGDPService
    {
        private readonly IGDPRepository _gdpRepo;

        public GDPService(IGDPRepository  gdpRepo)
        {
            _gdpRepo = gdpRepo;
        }

        public async Task<IEnumerable<GDP>> GetGDPs()
        {
            return await _gdpRepo.GetAllAsyn();
        }

        public async Task<IEnumerable<GDP>> GetGDPAllIndustry()
        {
            var gbdAllIndustryVectorId = Data.DataConstants.VectorId.GDP_ALL_INDUSTRIES;
            ParameterExpression parameter = Expression.Parameter(typeof(GDP));
            MemberExpression memberExpression = Expression.Property(parameter, "Vector_id");

            Expression right = Expression.Constant(gbdAllIndustryVectorId);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<GDP, bool>> predicate = Expression.Lambda<Func<GDP, bool>>(predicateBody, parameter);

            return await _gdpRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<GDP>> GetGDPsByVector(string vector_id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(GDP));

            MemberExpression memberExpression = Expression.Property(parameter, "vector_id");
            Expression right = Expression.Constant(vector_id);
            Expression predicateBody = Expression.Equal(right, memberExpression);

            Expression<Func<GDP, bool>> predicate = Expression.Lambda<Func<GDP, bool>>(predicateBody, parameter);

            return await _gdpRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<GDP>> GetGDPsByVectors(string vector_ids)
        {
            string[] vector_ids_str = vector_ids.Split(',');

            ParameterExpression parameter = Expression.Parameter(typeof(GDP));
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

            Expression<Func<GDP, bool>> predicate = Expression.Lambda<Func<GDP, bool>>(predicateBody, parameter);

            return await _gdpRepo.FindByAsyn(predicate);
        }
    }
}