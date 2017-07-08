using Data.DatabaseModels.CompleteModel;

namespace Domain.Entities.Junctions
{
    internal class Clubs_EmailsDTO
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int EmailId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public virtual Club Club { get; set; }
        public virtual Email Email { get; set; }
    }
}