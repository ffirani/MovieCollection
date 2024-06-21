using FluentValidation;

namespace MovieCollection.API.Commands.Validator
{
    public class DisassociateFromSelectionValidator : AbstractValidator<DisassociateFromSelectionCommand>
    {
        public DisassociateFromSelectionValidator()
        {
            RuleFor(a => a.MovieId).NotEmpty();
            RuleFor(m => m.SelectionId).NotEmpty();
        }
    }
}
