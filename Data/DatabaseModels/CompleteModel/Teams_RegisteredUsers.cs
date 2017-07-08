namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Teams_RegisteredUsers : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int RegisteredUserId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Team Team { get; set; }
    }
}