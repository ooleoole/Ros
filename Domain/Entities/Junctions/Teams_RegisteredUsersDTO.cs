namespace Domain.Entities.Junctions
{
    internal class Teams_RegisteredUsersDTO
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }
        public int RegisteredUserId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
    }
}