using Domain.Interfaces.Entities;
using System;

namespace Ros.Mapping.DomainModels
{
    internal class RaceEventModel : IRaceEvent, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxParticipants { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IRegatta Regatta { get; set; }
    }
}