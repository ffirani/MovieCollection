﻿namespace MovieCollection.API.Core.Authentication
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Guid GetUserIdentity()
        {
            var userid = _context.HttpContext.User.FindFirst("sub")?.Value;
            if(String.IsNullOrEmpty(userid))
            {
                return Guid.Empty;
            }
            return Guid.Parse(userid);
        }
    }
}
