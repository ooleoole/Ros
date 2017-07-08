namespace Domain.Interfaces.Entities
{
    public interface IEmail : IDboInfo
    {
        int Id { get; set; }
        string Value { get; set; }
        string Type { get; set; }
    }
}