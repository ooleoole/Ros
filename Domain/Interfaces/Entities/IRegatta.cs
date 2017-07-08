using System;

namespace Domain.Interfaces.Entities
{
    public interface IRegatta : IDboInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int Fee { get; set; }
        string Description { get; set; }
        IAddress Address { get; set; }
        IClub Club { get; set; }
    }
}