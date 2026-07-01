using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.DbExtensions
{

    /// <summary>
    /// 拼接linq
    /// </summary>
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        //注意，经我实际应用，发现第一种方法PredicateExtensions类有个缺陷，就是仅适合在DbDataContext中使用，若用在EntityContext中，则会报错：
        //    LINQ to Entities 不支持 LINQ 表达式节点类型“Invoke”。而使用第二种方法则不会有这个问题
        //第一种：
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first  
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression   
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        ////第二种：
        //public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        //{
        //    // build parameter map (from parameters of second to parameters of first)
        //    var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
        //    // replace parameters in the second lambda expression with parameters from the first
        //    var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
        //    // apply composition of lambda expression bodies to parameters from the first expression
        //    return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        //}

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
}
