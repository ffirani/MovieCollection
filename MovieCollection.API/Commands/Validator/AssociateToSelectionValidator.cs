using FluentValidation;

namespace MovieCollection.API.Commands.Validator
{
    public class AssociateToSelectionValidator:AbstractValidator<AssociateToSelectionCommand>
    {
        public AssociateToSelectionValidator() 
        {
            RuleFor(a => a.MovieId).NotEmpty();
            RuleFor(m => m.SelectionId).NotEmpty();
        }
    }
}
