using FluentValidation;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Dto;

namespace MovieCollection.API.Commands.Validator
{
    public class CreateMovieValidator : AbstractValidator<CreateEntityCommand<MovieDto>>
    {
        public CreateMovieValidator()
        {
            RuleFor(m => m.Data).NotEmpty();
            RuleFor(m => m.Data.Title).NotEmpty();
            RuleFor(m => m.Data.ReleaseData).NotEmpty();
        }
    }
}
