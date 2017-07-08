using System;

namespace Domain.Interfaces.Entities
{
    public interface IClub : IDboInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime RegistrationDate { get; set; }
        string Logo { get; set; }
        string HomePage { get; set; }
        string Description { get; set; }
        IAddress Address { get; set; }
    }
}