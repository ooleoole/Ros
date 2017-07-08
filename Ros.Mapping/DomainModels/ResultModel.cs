using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    internal class ResultModel : IResult, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public int? Rank { get; set; }
        public int? Points { get; set; }
        public int? Time { get; set; }
        public int? Distance { get; set; }
        public int? CalculatedTime { get; set; }
        public int? CalculatedDistance { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IEntry Entry { get; set; }
        public IRaceEvent RaceEvent { get; set; }
    }
}