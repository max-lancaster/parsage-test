using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using parsage_test.Application.Common.Interfaces;
using parsage_test.Application.Common.Mappings;
using parsage_test.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Bikes.Queries;

public record GetBikesQuery: IRequest<BikesVm>;

public class GetBikesQueryHandler : IRequestHandler<GetBikesQuery, BikesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBikesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BikesVm> Handle(GetBikesQuery request, CancellationToken cancellationToken)
    {
        return new BikesVm
        {
            Bikes = await _context.Bikes
                .AsNoTracking()
                .ProjectTo<BikeDto>(_mapper.ConfigurationProvider)
                .OrderBy(b => b.Model)
                .ToListAsync(cancellationToken)
        };
    }
}

public class BikeDto : IMapFrom<Bike>
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string Model { get; set; }
    public int FrameSize { get; set; }
    public decimal Price { get; set; }
}

public class ManufacturerDto : IMapFrom<Manufacturer>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class BikesVm
{
    public IList<BikeDto> Bikes { get; set; }
    public IList<ManufacturerDto> Manufacturers { get; set; }
}