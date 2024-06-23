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
            int currentPageSize = request.PageSize;
            if (currentPageSize <= 0) 
            {
                currentPageSize = 50; 
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
            var result = await _dbContext.Query<TView>().Where(expression).Skip(request.PageIndex).Take(currentPageSize).ToListAsync();
            var reponse = new RetrieveMultipleEntityResponse<TView>() { Entities = result };
            return reponse;
        }
    }
}
