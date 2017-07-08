using Data.DatabaseModels.CompleteModel;

namespace Domain.Entities.Junctions
{
    internal class Clubs_PhoneNumbersDTO
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int PhoneNumberId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public virtual Club Club { get; set; }
        public virtual PhoneNumber PhoneNumber { get; set; }
    }
}