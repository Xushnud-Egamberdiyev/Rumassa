namespace Rumassa.Domain.Entities;

public class Coupon
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
    public int Limit { get; set; } = 2;
    public short Persent { get; set; } = 10;

}
