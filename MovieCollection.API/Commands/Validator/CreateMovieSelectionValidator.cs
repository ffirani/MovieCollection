using FluentValidation;
using MovieCollection.API.Commands.Dto;

namespace MovieCollection.API.Commands.Validator
{
    public class CreateMovieSelectionValidator : AbstractValidator<CreateEntityCommand<MovieSelectionDto>>
    {
        public CreateMovieSelectionValidator()
        {
            RuleFor(m => m.Data).NotEmpty();
            RuleFor(m => m.Data.Name).NotEmpty();
        }
    }
}
