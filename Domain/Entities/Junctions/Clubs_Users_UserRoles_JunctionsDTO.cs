using Domain.Interfaces;

namespace Domain.Entities.Junctions
{
    internal interface IClubsRoleJunction : IRoleJunction
    {
        int ClubId { get; set; }
    }

    internal class Clubs_Users_UserRoles_JunctionsDTO : IClubsRoleJunction
    {
        public int Id { get; private set; }
        public int ClubId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public int? PhoneNumberId { get; set; }
        public int? EmailId { get; set; }
        public string sa_Info { get; set; }
        public bool Active { get; set; }
    }
}