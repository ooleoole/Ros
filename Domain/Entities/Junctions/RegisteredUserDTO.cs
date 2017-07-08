namespace Domain.Entities.Junctions
{
    internal class RegisteredUserDTO
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public EntryDTO Entry { get; set; }
        public UserDTO User { get; set; }
    }
}