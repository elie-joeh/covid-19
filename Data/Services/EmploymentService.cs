using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace covid19.Data
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IEmploymentRepository _employmentRepo;

        public EmploymentService(IEmploymentRepository employmentRepo)
        {
            _employmentRepo = employmentRepo;
        }

        public async Task<IEnumerable<Employment>> GetEmploymentByGroup(int groupNumber)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));
            MemberExpression memberExpression = Expression.Property(parameter, "AgeGroup");

            Expression right = Expression.Constant(groupNumber);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmployments()
        {
            return await _employmentRepo.GetAllAsyn();
        }

        public async Task<IEnumerable<Employment>> GetEmploymentsByGeo(string geoName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));
            MemberExpression memberExpression = Expression.Property(parameter, "GeoName");

            Expression right = Expression.Constant(geoName);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);

        }

        public async Task<IEnumerable<Employment>> GetEmploymentsByLfc(int lfc)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));
            MemberExpression memberExpression = Expression.Property(parameter, "Lfc");

            Expression right = Expression.Constant(lfc);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmploymentsBySex(int sex)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));
            MemberExpression memberExpression = Expression.Property(parameter, "Sex");

            Expression right = Expression.Constant(sex);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmploymentByLfcSexGroup(int lfc, int sex, int groupNumber)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));

            MemberExpression memberExpression1 = Expression.Property(parameter, "Lfc");
            Expression right1 = Expression.Constant(lfc);
            Expression e1 = Expression.Equal(memberExpression1, right1);

            MemberExpression memberExpression2 = Expression.Property(parameter, "Sex");
            Expression right2 = Expression.Constant(sex);
            Expression e2 = Expression.Equal(memberExpression2, right2);

            MemberExpression memberExpression3 = Expression.Property(parameter, "AgeGroup");
            Expression right3 = Expression.Constant(groupNumber);
            Expression e3 = Expression.Equal(memberExpression3, right3);

            Expression predicateBody = Expression.AndAlso(e1, e2);
            predicateBody = Expression.AndAlso(predicateBody, e3);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmploymentBySexGroup(int sex, int groupNumber)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Employment));

            MemberExpression memberExpression2 = Expression.Property(parameter, "Sex");
            Expression right2 = Expression.Constant(sex);
            Expression e2 = Expression.Equal(memberExpression2, right2);

            MemberExpression memberExpression3 = Expression.Property(parameter, "AgeGroup");
            Expression right3 = Expression.Constant(groupNumber);
            Expression e3 = Expression.Equal(memberExpression3, right3);

            Expression predicateBody = Expression.AndAlso(e2, e3);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmploymentBySexesGroup(int sex, int groupNumber)
        {
            int first_sex = sex % 10;
            int second_sex = sex / 10;

            ParameterExpression parameter = Expression.Parameter(typeof(Employment));

            MemberExpression memberExpression1 = Expression.Property(parameter, "sex");
            Expression right1 = Expression.Constant(first_sex);
            Expression e1 = Expression.Equal(memberExpression1, right1);

            MemberExpression memberExpression2 = Expression.Property(parameter, "sex");
            Expression right2 = Expression.Constant(second_sex);
            Expression e2 = Expression.Equal(memberExpression2, right2);

            Expression predicateBody = Expression.OrElse(e1, e2);

            MemberExpression memberExpression3 = Expression.Property(parameter, "AgeGroup");
            Expression right3 = Expression.Constant(groupNumber);
            Expression e3 = Expression.Equal(memberExpression3, right3);

            predicateBody = Expression.AndAlso(predicateBody, e3);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<Employment>> GetEmploymentByLfcSexGroups(int lfc, int sex, int groupNumbers)
        {
            //for only 1 group we already have a method that handles it
            if(groupNumbers < 10)
            {
                return await GetEmploymentByLfcSexGroup(lfc, sex, groupNumbers);
            }

            List<int> groups = new List<int>();
            while(groupNumbers != 0)
            {

                groups.Add(groupNumbers % 10);
                groupNumbers = groupNumbers / 10;
            }

            ParameterExpression parameter = Expression.Parameter(typeof(Employment));
            Expression predicateBody = null;

            for (var i=1; i<groups.Count(); i++)
            {
                MemberExpression memberExpression1 = Expression.Property(parameter, "AgeGroup");
                Expression right1 = Expression.Constant(groups[i]);
                Expression e1 = Expression.Equal(memberExpression1, right1);

                if (predicateBody == null)
                {
                    MemberExpression memberExpression2 = Expression.Property(parameter, "AgeGroup");
                    Expression right2 = Expression.Constant(groups[i-1]);
                    Expression e2 = Expression.Equal(memberExpression2, right2);

                    predicateBody = Expression.OrElse(e1, e2);
                } else
                {
                    predicateBody = Expression.OrElse(e1, predicateBody);
                }
                    
            }
            MemberExpression memberExpression = Expression.Property(parameter, "sex");
            Expression right = Expression.Constant(sex);
            Expression e3 = Expression.Equal(memberExpression, right);

            predicateBody = Expression.AndAlso(predicateBody, e3);

            memberExpression = Expression.Property(parameter, "Lfc");
            right = Expression.Constant(lfc);
            e3 = Expression.Equal(memberExpression, right);
            
            predicateBody = Expression.AndAlso(predicateBody, e3);

            Expression<Func<Employment, bool>> predicate = Expression.Lambda<Func<Employment, bool>>(predicateBody, parameter);

            return await _employmentRepo.FindByAsyn(predicate);
        }


    }
}