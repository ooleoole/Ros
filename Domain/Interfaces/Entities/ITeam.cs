namespace Domain.Interfaces.Entities
{
    public interface ITeam : IDboInfo
    {
        int Id { get; set; }
        int TeamNo { get; set; }
        string TeamName { get; set; }
        IEntry Entry { get; set; }
    }
}