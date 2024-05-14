namespace Rumassa.Domain.Entities;

public class Delivery
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Index { get; set; }
    public string StreetHouse { get; set; }
    public string Details { get; set; }
}
