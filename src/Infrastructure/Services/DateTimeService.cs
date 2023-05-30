using parsage_test.Application.Common.Interfaces;

namespace parsage_test.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
