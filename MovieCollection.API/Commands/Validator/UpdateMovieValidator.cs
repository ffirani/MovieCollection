using FluentValidation;
using MovieCollection.API.Commands.Dto;

namespace MovieCollection.API.Commands.Validator
{
    public class UpdateMovieValidator : AbstractValidator<UpdateEntityCommand<MovieDto>>
    {
        public UpdateMovieValidator()
        {
            RuleFor(m => m.Data).NotEmpty();
            RuleFor(m => m.Data.Title).NotEmpty();
            RuleFor(m => m.Data.ReleaseData).NotEmpty();
        }
    }
}
