using Domain.Entities.Junctions;
using Domain.Interfaces;
using Domain.Interfaces.Entities;
using Domain.Services.Locator;
using Domain.Utilities.RoleHandlers;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class RaceEventDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxParticipants { get; set; }
        public int RegattaId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public RegattaDTO Regatta { get; private set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public IRoleHandler RoleHandler => new RaceEventRoleHandler(this);

        public RaceEventDTO(string name, string location, int fee, DateTime startDate, DateTime endDate, int maxParticipants, int regattaId, string @class, string type, string description, string sa_Info = null)
        {
            ValidateInParameters(name, location, fee, startDate, endDate, maxParticipants, regattaId, @class, type);

            Name = name;
            Location = location;
            Fee = fee;
            StartDate = startDate;
            EndDate = endDate;
            MaxParticipants = MaxParticipants;
            RegattaId = regattaId;
            Class = @class;
            Type = type;
            Description = description;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public RaceEventDTO(IRaceEvent raceEvent)
        {
            if (raceEvent.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(raceEvent.Id)} cannot be less than 0.");
            RegattaDTO regatta = new RegattaDTO(raceEvent.Regatta);
            ValidateInParameters(raceEvent.Name, raceEvent.Location, raceEvent.Fee, raceEvent.StartDate, raceEvent.EndDate, raceEvent.MaxParticipants, raceEvent.Regatta.Id, raceEvent.Class, raceEvent.Type);

            Id = raceEvent.Id;
            Name = raceEvent.Name;
            Location = raceEvent.Location;
            Fee = raceEvent.Fee;
            Description = raceEvent.Description;
            StartDate = raceEvent.StartDate;
            EndDate = raceEvent.EndDate;
            MaxParticipants = raceEvent.MaxParticipants;
            RegattaId = raceEvent.Regatta.Id;
            Active = raceEvent.Active;
            sa_Info = raceEvent.sa_Info;
            Regatta = regatta;
            Class = raceEvent.Class;
            Type = raceEvent.Type;
        }

        private void ValidateInParameters(string name, string location, int fee, DateTime startDate, DateTime endDate, int maxParticipants, int regattaId, string @class, string type)
        {
            // TODO: Implement validation!
        }

        public void AddTeamToRaceEvent(UserDTO caller, TeamDTO teamToAdd)
        {
            Utilities.NullCheck.ThrowArgumentNullEx(caller, teamToAdd);
            if (caller.Permissions.GetRaceEventRegistrationPermissions().All(regPer => regPer.Id != Id))
                throw new ArgumentException($"User: {caller.Login}, Id: {caller.Id} dose not have permission to add teams to this RaceEvent" +
                                            $"The user calling this metod must be ResponsiblePerson on a Entry that is registered on the regatta hosting the RaceEvent");
            if (teamToAdd.GetTeamMembers().Any(u => u.Permissions.GetAttendancePermissions<RaceEventDTO>().Any(rePer => rePer.Id != Id)))
                throw new ArgumentException($"Atleast one user in the team dose not have permission to attend this event");

            teamToAdd = Utilities.DbEntityExistensChecker.TryGetExistingTeamFromDb(teamToAdd) ?? Utilities.DbEntityAdder.AddTeamToDb(teamToAdd);
            AddTeamRelationToDb(CreateTeamRaceEventRelation(teamToAdd));
        }

        public void CheckPermissionAllowSelfHandling(UserDTO caller, UserDTO user)
        {
            Utilities.NullCheck.ThrowArgumentNullEx(caller, user);
            if (!(caller.Login == user.Login ||
                  caller.Permissions.GetClubAdminPermissons<RaceEventDTO>().Any(t => t.Id == Id)))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermission(UserDTO caller)
        {
            Utilities.NullCheck.ThrowArgumentNullEx(caller);
            if (caller.Permissions.GetClubAdminPermissons<RaceEventDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionToAffiliatedRegatta(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<RegattaDTO>().All(t => t.Id != RegattaId))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        private void AddTeamRelationToDb(Teams_RaceEventsDTO relation)
        {
            ServiceLocator.TeamRaceEventService.Add(relation);
        }

        private Teams_RaceEventsDTO CreateTeamRaceEventRelation(TeamDTO teamToAdd)
        {
            return new Teams_RaceEventsDTO()
            {
                RaceEventId = Id,
                TeamId = teamToAdd.Id
            };
        }
    }
}