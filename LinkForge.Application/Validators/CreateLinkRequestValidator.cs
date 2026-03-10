using FluentValidation;
using LinkForge.Application.DTO;

namespace LinkForge.Application.Validators;

public class CreateLinkRequestValidator : AbstractValidator<CreateLinkRequestDto>
{
    public CreateLinkRequestValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(2000);

        RuleFor(x => x.Url)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .When(x => !string.IsNullOrWhiteSpace(x.Url))
            .WithMessage("URL must be valid");
    }
}