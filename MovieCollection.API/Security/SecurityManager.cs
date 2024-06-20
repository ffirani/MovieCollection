using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;
using System.Security.Claims;

namespace MovieCollection.API.Security
{
    public class SecurityManager : ISecurityManager
    {

        public bool HasPermissionToRuneCommnad<TRequest>(ClaimsPrincipal user, TRequest request) where TRequest : class
        {
            if (user == null) throw new ArgumentNullException("Invalid user value");
            if (request == null) throw new ArgumentNullException("Invalid request value");

            if (request is CreateEntityCommand<PersonDto> ||
                request is CreateEntityCommand<MovieDto> ||
                request is CreateEntityCommand<GenreDto> ||
                request is DeleteEntityCommand<PersonDto> ||
                request is DeleteEntityCommand<MovieDto> ||
                request is DeleteEntityCommand<GenreDto>)
            {
                var isAdmin = user.IsInRole("Admin");
                if(isAdmin) 
                { 
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
