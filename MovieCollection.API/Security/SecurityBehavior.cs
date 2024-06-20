using MediatR;

namespace MovieCollection.API.Security
{
    public class SecurityBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISecurityManager _securityManager;
        public SecurityBehavior(IHttpContextAccessor httpContextAccessor, ISecurityManager securityManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _securityManager = securityManager;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                var user = httpContext.User;
                if (user != null && user.Identity.IsAuthenticated)
                {
                    var hasPermissionToRunCommnad = _securityManager.HasPermissionToRuneCommnad(user, request);
                    if (!hasPermissionToRunCommnad)
                    {
                        throw new UnauthorizedAccessException("User does not have the required  role.");
                    }

                    return await next();

                }
            }

            throw new UnauthorizedAccessException("User is not authenticated.");
        }
    }
}
