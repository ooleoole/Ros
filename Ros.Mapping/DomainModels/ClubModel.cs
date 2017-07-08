using Domain.Interfaces.Entities;
using System;

namespace Ros.Mapping.DomainModels
{
    internal class ClubModel : IClub, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string Logo { get; set; }
        public string HomePage { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IAddress Address { get; set; }
    }
}