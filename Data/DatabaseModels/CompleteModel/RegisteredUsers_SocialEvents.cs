namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class RegisteredUsers_SocialEvents : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int RegisteredUserId { get; set; }

        public int SocialEventId { get; set; }

        public int NoOfFriends { get; set; }

        public int PaidAmount { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual SocialEvent SocialEvent { get; set; }
    }
}