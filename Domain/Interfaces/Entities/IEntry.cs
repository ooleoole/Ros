using System;

namespace Domain.Interfaces.Entities
{
    public interface IEntry : IDboInfo
    {
        int Id { get; set; }
        int EntryNo { get; set; }
        string EntryName { get; set; }
        DateTime RegistrationDate { get; set; }
        int PaidAmount { get; set; }
        IBoat Boat { get; set; }
        IClub Club { get; set; }
        IUser User { get; set; }
        IRegatta Regatta { get; set; }
    }
}