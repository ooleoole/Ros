namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Clubs_Users_UserRoles_Junctions = new HashSet<Clubs_Users_UserRoles_Junctions>();
            Entries = new HashSet<Entry>();
            RaceEvents_Users_UserRoles_Junctions = new HashSet<RaceEvents_Users_UserRoles_Junctions>();
            Regattas_Users_UserRoles_Junctions = new HashSet<Regattas_Users_UserRoles_Junctions>();
            RegisteredUsers = new HashSet<RegisteredUser>();
            SocialEvents_Users_UserRoles_Junctions = new HashSet<SocialEvents_Users_UserRoles_Junctions>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Login { get; set; }

        [Required]
        [StringLength(512)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string ICE_Name { get; set; }

        [StringLength(32)]
        public string ICE_PhoneNumber { get; set; }

        public int PhoneNumberId { get; set; }

        public int AddressId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clubs_Users_UserRoles_Junctions> Clubs_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvents_Users_UserRoles_Junctions> RaceEvents_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regattas_Users_UserRoles_Junctions> Regattas_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEvents_Users_UserRoles_Junctions> SocialEvents_Users_UserRoles_Junctions { get; set; }
    }
}