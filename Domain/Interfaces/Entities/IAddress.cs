namespace Domain.Interfaces.Entities
{
    public interface IAddress : IDboInfo
    {
        int Id { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }
        int? BoxNo { get; set; }
        string Type { get; set; }
    }
}