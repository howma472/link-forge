using FluentValidation;
using LinkForge.Application.DTO;

namespace LinkForge.Application.Validators;

public class UpdateLinkRequestValidator : AbstractValidator<UpdateLinkRequestDto>
{
    public UpdateLinkRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.OriginalUrl)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(2000);

        RuleFor(x => x.OriginalUrl)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Invalid URL format");
    }
}