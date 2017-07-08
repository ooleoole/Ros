namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Boat : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Boat()
        {
            Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }

        public int SailNo { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [StringLength(256)]
        public string Handicap { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }
    }
}