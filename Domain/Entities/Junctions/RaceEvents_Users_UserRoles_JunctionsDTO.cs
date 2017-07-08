using Domain.Interfaces;

namespace Domain.Entities.Junctions
{
    internal interface IRaceEventsRoleJunction : IRoleJunction
    {
        int RaceEventId { get; set; }
    }

    internal class RaceEvents_Users_UserRoles_JunctionsDTO : IRaceEventsRoleJunction
    {
        public int Id { get; set; }

        public int RaceEventId { get; set; }

        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public int? PhoneNumberId { get; set; }

        public int? EmailId { get; set; }

        public bool Active { get; set; }

        public string sa_Info { get; set; }
    }
}