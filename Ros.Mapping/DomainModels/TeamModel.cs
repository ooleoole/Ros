using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    internal class TeamModel : ITeam, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public int TeamNo { get; set; }
        public string TeamName { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IEntry Entry { get; set; }
    }
}