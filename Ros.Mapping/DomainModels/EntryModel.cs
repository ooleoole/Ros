using Domain.Interfaces.Entities;
using System;

namespace Ros.Mapping.DomainModels
{
    internal class EntryModel : IEntry, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public int EntryNo { get; set; }
        public string EntryName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int PaidAmount { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IBoat Boat { get; set; }
        public IClub Club { get; set; }
        public IUser User { get; set; }
        public IRegatta Regatta { get; set; }
    }
}