namespace Domain.Interfaces.Entities
{
    public interface IResult : IDboInfo
    {
        int Id { get; set; }
        int? Rank { get; set; }
        int? Points { get; set; }
        int? Time { get; set; }
        int? Distance { get; set; }
        int? CalculatedTime { get; set; }
        int? CalculatedDistance { get; set; }
        string Remark { get; set; }
        IEntry Entry { get; set; }
        IRaceEvent RaceEvent { get; set; }
    }
}