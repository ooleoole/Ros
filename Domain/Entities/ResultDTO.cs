using Domain.Interfaces;
using Domain.Interfaces.Entities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class ResultDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public int? Rank { get; set; }
        public int? Points { get; set; }
        public int? Time { get; set; }
        public int? Distance { get; set; }
        public int? CalculatedTime { get; set; }
        public int? CalculatedDistance { get; set; }
        public string Remark { get; set; }
        public int EntryId { get; set; }
        public int RaceEventId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public EntryDTO Entry { get; private set; }
        public RaceEventDTO RaceEvent { get; private set; }

        public ResultDTO(int entryId, int raceEventId, string remark, int? rank = null, int? points = null, int? time = null, int? distance = null, int? calculatedTime = null, int? calculatedDistance = null, string sa_Info = null)
        {
            ValidateInParameters(entryId, raceEventId, rank, points, time, distance, calculatedTime, calculatedDistance, remark);

            Id = 0;
            Rank = rank;
            Points = points;
            Time = time;
            Distance = distance;
            CalculatedTime = calculatedTime;
            CalculatedDistance = calculatedDistance;
            Remark = remark;
            EntryId = entryId;
            RaceEventId = raceEventId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public ResultDTO(IResult result)
        {
            if (result.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(result.Id)} cannot be less than 0.");
            ValidateInParameters(result.Entry.Id, result.RaceEvent.Id, result.Rank, result.Points, result.Time, result.Distance, result.CalculatedTime, result.CalculatedDistance, result.Remark);
            EntryDTO entry = new EntryDTO(result.Entry);
            RaceEventDTO raceEvent = new RaceEventDTO(result.RaceEvent);

            Id = result.Id;
            Rank = result.Rank;
            Points = result.Points;
            Time = result.Time;
            Distance = result.Distance;
            CalculatedTime = result.CalculatedTime;
            CalculatedDistance = result.CalculatedDistance;
            Remark = result.Remark;
            EntryId = result.Entry.Id;
            RaceEventId = result.RaceEvent.Id;
            Entry = entry;
            RaceEvent = raceEvent;
            Active = result.Active;
            sa_Info = result.sa_Info;
        }

        private void ValidateInParameters(int entryId, int raceEventId, int? rank, int? points, int? time, int? distance, int? calculatedTime, int? calculatedDistance, string remark)
        {
            // TODO: Implement validation!
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<ResultDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionToAffiliatedRaceEvent(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<RaceEventDTO>().All(t => t.Id != RaceEventId))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }
    }
}