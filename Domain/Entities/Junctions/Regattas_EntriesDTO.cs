namespace Domain.Entities.Junctions
{
    internal class Regattas_EntriesDTO
    {
        public int Id { get; private set; }
        public int EntryId { get; set; }
        public int RegattaId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
    }
}