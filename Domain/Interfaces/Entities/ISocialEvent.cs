using System;

namespace Domain.Interfaces.Entities
{
    public interface ISocialEvent : IDboInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        int Fee { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int MaxParticipants { get; set; }
        IRegatta Regatta { get; set; }
    }
}