using MediatR;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Infrastructure.Error;
using MovieCollection.Query.Db.Base;
using MovieCollection.Query.View.Base;
using System.Threading;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQueryHandler<TView> : IRequestHandler<RetrieveEntityQuery<TView>, RetrieveEntityResponse<TView>> where TView:BaseView
    {
        private IReadOnlyDbContext _dbContext;
        public RetrieveEntityQueryHandler(IReadOnlyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<RetrieveEntityResponse<TView>> Handle(RetrieveEntityQuery<TView> request, CancellationToken cancellationToken)
        {
            var view = _dbContext.Query<TView>().FirstOrDefault(v=>v.Id == request.Id);
            if (view == null)
            {
                throw new AppException("ERR2001", $"View with id {request.Id} does not exist.");
            }
            return new RetrieveEntityResponse<TView> { View = view };
        }
    }
}
