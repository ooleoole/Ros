using Domain.Interfaces;

namespace Domain.Entities.Junctions
{
    internal interface IRegattasRoleJunction : IRoleJunction
    {
        int RegattaId { get; set; }
    }

    internal class Regattas_Users_UserRoles_JunctionsDTO : IRegattasRoleJunction
    {
        public int Id { get; set; }
        public int RegattaId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public int? PhoneNumberId { get; set; }
        public int? EmailId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public EmailDTO Email { get; set; }
        public PhoneNumberDTO PhoneNumber { get; set; }
        public RegattaDTO Regatta { get; set; }
        public UserDTO User { get; set; }
        public UserRoleDTO UserRole { get; set; }
    }
}