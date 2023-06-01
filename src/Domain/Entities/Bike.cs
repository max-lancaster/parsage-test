namespace parsage_test.Domain.Entities;

public class Bike: BaseAuditableEntity
{
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public string Model { get; set; }
    public int FrameSize { get; set; }
    public decimal Price { get; set; }
}