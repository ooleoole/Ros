namespace Data.DatabaseModels.CompleteModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Address : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Clubs = new HashSet<Club>();
            Regattas = new HashSet<Regatta>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Country { get; set; }

        [Required]
        [StringLength(64)]
        public string City { get; set; }

        [Required]
        [StringLength(256)]
        public string Street { get; set; }

        [Required]
        [StringLength(16)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(32)]
        public string Type { get; set; }

        public int? BoxNo { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Club> Clubs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regatta> Regattas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}