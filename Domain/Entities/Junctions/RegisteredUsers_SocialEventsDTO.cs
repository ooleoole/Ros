namespace Domain.Entities.Junctions
{
    internal class RegisteredUsers_SocialEventsDTO
    {
        public int Id { get; private set; }
        public int RegisteredUserId { get; set; }
        public int SocialEventId { get; set; }
        public int NoOfFriends { get; set; }
        public int PaidAmount { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
    }
}