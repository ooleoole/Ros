namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Regattas_Users_UserRoles_Junctions : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int RegattaId { get; set; }

        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public int? PhoneNumberId { get; set; }

        public int? EmailId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Email Email { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        public virtual Regatta Regatta { get; set; }

        public virtual User User { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}