using FluentValidation;
using MovieCollection.API.Commands.Dto;

namespace MovieCollection.API.Commands.Validator
{
    public class UpdateMovieSelectionValidator : AbstractValidator<UpdateEntityCommand<MovieSelectionDto>>
    {
        public UpdateMovieSelectionValidator()
        {
            RuleFor(m => m.Data).NotEmpty();
            RuleFor(m => m.Data.Name).NotEmpty();
        }
    }
}
