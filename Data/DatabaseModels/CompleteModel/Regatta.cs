namespace Data.DatabaseModels.CompleteModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Regatta : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regatta()
        {
            Entries = new HashSet<Entry>();
            RaceEvents = new HashSet<RaceEvent>();
            Regattas_Users_UserRoles_Junctions = new HashSet<Regattas_Users_UserRoles_Junctions>();
            SocialEvents = new HashSet<SocialEvent>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Fee { get; set; }

        public string Description { get; set; }

        public int ClubId { get; set; }

        public int AddressId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Address Address { get; set; }

        public virtual Club Club { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvent> RaceEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regattas_Users_UserRoles_Junctions> Regattas_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEvent> SocialEvents { get; set; }
    }
}