using MovieCollection.Query.View.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.Parser
{
    public interface IQueryParser<T> where T : BaseView
    {
        Expression<Func<T, bool>> Pars(QueryExpression query);
    }
}
