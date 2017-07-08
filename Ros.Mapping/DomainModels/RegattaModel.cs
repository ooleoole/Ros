using Domain.Interfaces.Entities;
using System;

namespace Ros.Mapping.DomainModels
{
    internal class RegattaModel : IRegatta, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IAddress Address { get; set; }
        public IClub Club { get; set; }
    }
}