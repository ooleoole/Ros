namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserRole : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRole()
        {
            Clubs_Users_UserRoles_Junctions = new HashSet<Clubs_Users_UserRoles_Junctions>();
            RaceEvents_Users_UserRoles_Junctions = new HashSet<RaceEvents_Users_UserRoles_Junctions>();
            Regattas_Users_UserRoles_Junctions = new HashSet<Regattas_Users_UserRoles_Junctions>();
            SocialEvents_Users_UserRoles_Junctions = new HashSet<SocialEvents_Users_UserRoles_Junctions>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Type { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clubs_Users_UserRoles_Junctions> Clubs_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvents_Users_UserRoles_Junctions> RaceEvents_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regattas_Users_UserRoles_Junctions> Regattas_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEvents_Users_UserRoles_Junctions> SocialEvents_Users_UserRoles_Junctions { get; set; }
    }
}