namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RegisteredUser : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisteredUser()
        {
            RegisteredUsers_SocialEvents = new HashSet<RegisteredUsers_SocialEvents>();
            Teams_RegisteredUsers = new HashSet<Teams_RegisteredUsers>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int EntryId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Entry Entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUsers_SocialEvents> RegisteredUsers_SocialEvents { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams_RegisteredUsers> Teams_RegisteredUsers { get; set; }
    }
}