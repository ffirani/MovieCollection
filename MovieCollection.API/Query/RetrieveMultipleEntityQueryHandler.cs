using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using MovieCollection.Query.Db.Base;
using MovieCollection.Query.Parser;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQueryHandler<TView> :
        IRequestHandler<RetrieveMultipleEntityQuery<TView>, RetrieveMultipleEntityResponse<TView>> where TView : BaseView
    {
        private IReadOnlyDbContext _dbContext;
        private IQueryParser<TView> _queryParser;

        public RetrieveMultipleEntityQueryHandler(IReadOnlyDbContext dbContext, IQueryParser<TView> queryParserr)
        {
            _dbContext = dbContext;
            _queryParser = queryParserr;
        }
        public async Task<RetrieveMultipleEntityResponse<TView>> Handle(RetrieveMultipleEntityQuery<TView> request, CancellationToken cancellationToken)
        {
            int pageSize = request.PageSize;
            if (pageSize <= 0)
            {
                pageSize = 50;
            }
            int pageIndex = request.PageIndex;
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            if (request == null)
            {
                throw new ArgumentNullException("Request can not be null for RetrieveMultipleEntityQueryHandler");
            }
            if (request.Expression == null)
            {
                throw new Exception("Expression must not be null");
            }
            var expression = _queryParser.Pars(request.Expression);
            var result = await _dbContext
                .Query<TView>()
                .Where(expression)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalCount = await _dbContext
                .Query<TView>()
                .CountAsync(expression);
            var reponse = new RetrieveMultipleEntityResponse<TView>()
            {
                Entities = result,
                TotalNumber = totalCount
            };
            return reponse;
        }
    }
}
