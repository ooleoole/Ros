namespace Data.DatabaseModels.CompleteModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Club : Interfaces.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            Clubs_Emails = new HashSet<Clubs_Emails>();
            Clubs_PhoneNumbers = new HashSet<Clubs_PhoneNumbers>();
            Clubs_Users_UserRoles_Junctions = new HashSet<Clubs_Users_UserRoles_Junctions>();
            Entries = new HashSet<Entry>();
            Regattas = new HashSet<Regatta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        [StringLength(1024)]
        public string Logo { get; set; }

        [StringLength(1024)]
        public string HomePage { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clubs_Emails> Clubs_Emails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clubs_PhoneNumbers> Clubs_PhoneNumbers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clubs_Users_UserRoles_Junctions> Clubs_Users_UserRoles_Junctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regatta> Regattas { get; set; }
    }
}