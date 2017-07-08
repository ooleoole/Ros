namespace Data.DatabaseModels.CompleteModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SocialEvent : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SocialEvent()
        {
            RegisteredUsers_SocialEvents = new HashSet<RegisteredUsers_SocialEvents>();
            SocialEvents_Users_UserRoles_Junctions = new HashSet<SocialEvents_Users_UserRoles_Junctions>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Location { get; set; }

        public int Fee { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int MaxParticipants { get; set; }

        public int RegattaId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Regatta Regatta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUsers_SocialEvents> RegisteredUsers_SocialEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEvents_Users_UserRoles_Junctions> SocialEvents_Users_UserRoles_Junctions { get; set; }
    }
}