namespace parsage_test.Domain.Events;

public class BikeCreatedEvent : BaseEvent
{
    public BikeCreatedEvent(Bike bike)
    {
        Bike = bike;
    }

    public Bike Bike { get; }
}
