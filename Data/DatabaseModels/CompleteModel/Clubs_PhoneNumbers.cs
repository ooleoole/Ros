namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Clubs_PhoneNumbers : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int ClubId { get; set; }

        public int PhoneNumberId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Club Club { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }
    }
}