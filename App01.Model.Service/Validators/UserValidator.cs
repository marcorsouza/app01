using App01.Model.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App01.Model.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the name.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the e-mail.");

            RuleFor(c => c.Authentication.Username)
                .NotEmpty().WithMessage("Is necessary to inform the username.")
                .NotNull().WithMessage("Is necessary to inform the username.");

            RuleFor(c => c.Authentication.Password)
                .NotEmpty().WithMessage("Is necessary to inform the password.")
                .NotNull().WithMessage("Is necessary to inform the password.");
        }
    }

    public class UpdateUserValidator : AbstractValidator<User>
    {
        public UpdateUserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the name.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Is necessary to inform the e-mail.")
                .NotNull().WithMessage("Is necessary to inform the e-mail.");
        }
    }

    public class UpdatePasswordValidator : AbstractValidator<User>
    {
        public UpdatePasswordValidator(string confirmPassword)
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });
            
            RuleFor(c => c.Authentication.Password)
                .NotEmpty().WithMessage("Is necessary to inform the password.")
                .NotNull().WithMessage("Is necessary to inform the password.");

            RuleFor(c => confirmPassword)
                .NotEmpty().WithMessage("Is necessary to inform the password.")
                .NotNull().WithMessage("Is necessary to inform the password.");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Authentication.Password != confirmPassword)
                {
                    context.AddFailure(nameof(x.Authentication.Password), "Passwords should match");
                }
            });
        }
    }
}
