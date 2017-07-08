using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    internal class BoatModel : IBoat, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public int SailNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Handicap { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
    }
}