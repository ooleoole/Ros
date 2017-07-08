namespace Data.DatabaseModels.CompleteModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Result : Interfaces.IEntity
    {
        public int Id { get; set; }

        public int? Rank { get; set; }

        public int? Points { get; set; }

        public int? Time { get; set; }

        public int? Distance { get; set; }

        public int? CalculatedTime { get; set; }

        public int? CalculatedDistance { get; set; }

        [StringLength(3)]
        public string Remark { get; set; }

        public int EntryId { get; set; }

        public int RaceEventId { get; set; }

        public bool Active { get; set; }

        [StringLength(512)]
        public string sa_Info { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }
    }
}