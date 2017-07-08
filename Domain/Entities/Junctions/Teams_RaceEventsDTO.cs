namespace Domain.Entities.Junctions
{
    internal class Teams_RaceEventsDTO
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }
        public int RaceEventId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
    }
}