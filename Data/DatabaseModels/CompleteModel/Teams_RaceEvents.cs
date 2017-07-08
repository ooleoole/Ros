namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Teams_RaceEvents : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int RaceEventId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        public virtual Team Team { get; set; }
    }
}