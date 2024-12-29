using FluentValidation;
using InnoTree.Application.Usecases.Decorations.Commands.CreateDecoration;
using InnoTree.Core.Dto.Request;

namespace InnoTree.Application.Validators;

public class CreateDecorationCommandValidator : AbstractValidator<CreateDecorationCommand>
{
    public CreateDecorationCommandValidator()
    {
        RuleFor(d => d.DecorationRequestDto.Author)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(d => d.DecorationRequestDto.Message)
            .MaximumLength(300)
            .NotEmpty();

        RuleFor(d => d.DecorationRequestDto.Type)
            .Must(d => 
            d.Equals("bell") || 
            d.Equals("red-ball") ||
            d.Equals("blue-ball") ||
            d.Equals("wreath"))
            .NotEmpty();

        RuleFor(d => d.DecorationRequestDto.X)
            .GreaterThan(0);

        RuleFor(d => d.DecorationRequestDto.Y)
            .GreaterThan(0);
    }
}
