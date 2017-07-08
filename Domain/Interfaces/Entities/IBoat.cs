namespace Domain.Interfaces.Entities
{
    public interface IBoat : IDboInfo
    {
        int Id { get; set; }
        int SailNo { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Handicap { get; set; }
    }
}