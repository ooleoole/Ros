namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Team : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            Teams_RaceEvents = new HashSet<Teams_RaceEvents>();
            Teams_RegisteredUsers = new HashSet<Teams_RegisteredUsers>();
        }

        public int Id { get; set; }

        public int TeamNo { get; set; }

        [Required]
        [StringLength(512)]
        public string TeamName { get; set; }

        public int EntryId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Entry Entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams_RaceEvents> Teams_RaceEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams_RegisteredUsers> Teams_RegisteredUsers { get; set; }
    }
}