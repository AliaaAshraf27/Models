using FluentValidation;
using MedicalServices.Features.ApplicationUser.Command.Models;

namespace MedicalServices.Features.ApplicationUser.Command.Validatiors
{
    // Validator class for the AddUserCommandDTO, responsible for validating input fields
    public class AddUserValidator : AbstractValidator<AddUserCommandDTo>
    {

        #region Constructors

        public AddUserValidator()
        {
            // Method that applies all validation rules to the AddUserCommandDTO fields
            ApplyValidationsRules();
        }
        #endregion

        #region Handel Functions
        // This method contains validation rules for each field of AddUserCommandDTO
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .NotNull().WithMessage("Email cannot be null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .NotNull().WithMessage("Password cannot be null");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number cannot be empty")
                .NotNull().WithMessage("Phone number cannot be null");


        }


        #endregion
    }
}
