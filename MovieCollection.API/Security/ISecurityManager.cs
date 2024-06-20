﻿using System.Security.Claims;

namespace MovieCollection.API.Security
{
    public interface ISecurityManager
    {
        bool HasPermissionToRuneCommnad<TRequest>(ClaimsPrincipal user, TRequest request) where TRequest : class;
    }
}
