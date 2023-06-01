using FluentValidation;
using MediatR;
using parsage_test.Application.Common.Interfaces;
using parsage_test.Domain.Entities;
using parsage_test.Domain.Events;

namespace parsage_test.Application.Bikes.Commands;

public record CreateBikeCommand : IRequest<int>
{
    public int ManufacturerId { get; init; }
    public string Model { get; init; }
    public int FrameSize { get; init; }
    public decimal Price { get; init; }
}

public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBikeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Bike
        {
            ManufacturerId = request.ManufacturerId,
            Model = request.Model,
            FrameSize = request.FrameSize,
            Price = request.Price
        };

        entity.AddDomainEvent(new BikeCreatedEvent(entity));

        _context.Bikes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

public class CreateBikeCommandValidator : AbstractValidator<CreateBikeCommand>
{
    public CreateBikeCommandValidator()
    {
        RuleFor(v => v.ManufacturerId).NotEmpty();
        RuleFor(v => v.Model).MaximumLength(50).NotEmpty();
        RuleFor(v => v.FrameSize).NotEmpty();
        RuleFor(v => v.Price).NotEmpty();
    }
}