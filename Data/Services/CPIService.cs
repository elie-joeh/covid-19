using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using covid19.Data;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace covid19.Data
{
    public class CPIService : ICPIService
    {
        private readonly ICPIRepository _cpiRepository;

        public CPIService(ICPIRepository cpiRepository)
        {
            _cpiRepository = cpiRepository;
        }

        public async Task<IEnumerable<CPI>> getCPIs()
        {
            return await _cpiRepository.GetAllAsyn();
        }

        public async Task<IEnumerable<CPI>> getCPIByPpdg(string ppdg)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CPI));
            MemberExpression memberExpression = Expression.Property(parameter, "Ppdg");

            Expression right = Expression.Constant(ppdg);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<CPI, bool>> predicate = Expression.Lambda<Func<CPI, bool>>(predicateBody, parameter);

            return await _cpiRepository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<CPI>> getCPIByGeo(string geographyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CPI));
            MemberExpression memberExpression = Expression.Property(parameter, "GeographyName");

            Expression right = Expression.Constant(geographyName);
            Expression predicateBody = Expression.Equal(memberExpression, right);

            Expression<Func<CPI, bool>> predicate = Expression.Lambda<Func<CPI, bool>>(predicateBody, parameter);

            return await _cpiRepository.FindByAsyn(predicate);
        }

        public async Task<IEnumerable<CPI>> getCPIByGeoByPPG(string geographyName, string ppdg)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CPI));

            MemberExpression memberExperssion1 = Expression.Property(parameter, "GeographyName");
            Expression right = Expression.Constant(geographyName);
            Expression e1 = Expression.Equal(memberExperssion1, right);

            MemberExpression memberExpression2 = Expression.Property(parameter, "Ppdg");
            right = Expression.Constant(ppdg);
            Expression e2 = Expression.Equal(memberExpression2, right);

            Expression predicateBody = Expression.AndAlso(e1, e2);

            Expression<Func<CPI, bool>> predicate = Expression.Lambda<Func<CPI, bool>>(predicateBody, parameter);

            return await _cpiRepository.FindByAsyn(predicate);
        }

    }
}