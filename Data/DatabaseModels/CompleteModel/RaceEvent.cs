namespace Data.DatabaseModels.CompleteModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RaceEvent : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceEvent()
        {
            RaceEvents_Users_UserRoles_Junctions = new HashSet<RaceEvents_Users_UserRoles_Junctions>();
            Results = new HashSet<Result>();
            Teams_RaceEvents = new HashSet<Teams_RaceEvents>();
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

        [Required]
        [StringLength(512)]
        public string Class { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvents_Users_UserRoles_Junctions> RaceEvents_Users_UserRoles_Junctions { get; set; }

        public virtual Regatta Regatta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams_RaceEvents> Teams_RaceEvents { get; set; }
    }
}