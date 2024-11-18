using FluentValidation;

namespace MotorSocialApp.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olabilir.")
                .MinimumLength(2).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır.")
                .WithName("İsim Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .MaximumLength(60).WithMessage("{PropertyName} en fazla {MaxLength} karakter olabilir.")
                .MinimumLength(8).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır.")
                .EmailAddress().WithMessage("{PropertyName} geçerli bir e-posta adresi olmalıdır.")
                .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .MinimumLength(6).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır.")
                .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .Equal(x => x.Password).WithMessage("{PropertyName}, Parola ile eşleşmelidir.")
                .WithName("Parola Tekrarı");
        }
    }
}
