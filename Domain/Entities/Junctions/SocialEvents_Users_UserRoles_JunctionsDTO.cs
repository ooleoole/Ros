using Domain.Interfaces;

namespace Domain.Entities.Junctions
{
    internal interface ISocialEventsRoleJunction : IRoleJunction
    {
        int SocialEventId { get; set; }
    }

    internal class SocialEvents_Users_UserRoles_JunctionsDTO : ISocialEventsRoleJunction
    {
        public int Id { get; set; }
        public int SocialEventId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public int? PhoneNumberId { get; set; }
        public int? EmailId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
    }
}