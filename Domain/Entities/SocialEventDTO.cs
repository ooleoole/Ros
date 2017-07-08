using Domain.Entities.Junctions;
using Domain.Interfaces;
using Domain.Interfaces.Entities;
using Domain.Services.Locator;
using Domain.Utilities;
using Domain.Utilities.RoleHandlers;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class SocialEventDTO : IPermissionTarget, IEntityDTO, IDboInfo
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
        public IRoleHandler RoleHandler => new SocialEventRoleHandler(this);

        public SocialEventDTO(string name, string location, int fee, DateTime startDate, DateTime endDate, int maxParticipants, int regattaId, string description = null, string sa_Info = null)
        {
            ValidateInParameters(name, location, fee, startDate, endDate, maxParticipants, regattaId);

            Id = 0;
            Name = name;
            Location = location;
            Fee = fee;
            StartDate = startDate;
            EndDate = endDate;
            MaxParticipants = maxParticipants;
            RegattaId = regattaId;
            Description = description;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public SocialEventDTO(ISocialEvent socialEvent)
        {
            if (socialEvent.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(socialEvent.Id)} cannot be less than 0.");
            RegattaDTO regatta = new RegattaDTO(socialEvent.Regatta);
            ValidateInParameters(socialEvent.Name, socialEvent.Location, socialEvent.Fee, socialEvent.StartDate, socialEvent.EndDate, socialEvent.MaxParticipants, socialEvent.Regatta.Id);

            Id = socialEvent.Id;
            Name = socialEvent.Name;
            Location = socialEvent.Location;
            Fee = socialEvent.Fee;
            Description = socialEvent.Description;
            StartDate = socialEvent.StartDate;
            EndDate = socialEvent.EndDate;
            MaxParticipants = socialEvent.MaxParticipants;
            RegattaId = socialEvent.Regatta.Id;
            Active = socialEvent.Active;
            sa_Info = socialEvent.sa_Info;
            Regatta = regatta;
        }

        private void ValidateInParameters(string name, string location, int fee, DateTime startDate, DateTime endDate, int maxParticipants, int regattaId)
        {
            // TODO: Implement validation!
        }

        public override int GetHashCode()
        {
            return (Fee.GetHashCode() + 7) ^ (Name.GetHashCode() + 7);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SocialEventDTO))
                return false;
            var other = (SocialEventDTO)obj;
            return this == other;
        }

        public static bool operator ==(SocialEventDTO s1, SocialEventDTO s2)
        {
            return s1.Id == s2.Id;
        }

        public static bool operator !=(SocialEventDTO s1, SocialEventDTO s2)
        {
            return !(s1 == s2);
        }

        public void CheckPermissionToAffiliatedRegatta(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<RegattaDTO>().All(t => t.Id != RegattaId))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionAllowSelfHandling(UserDTO caller, UserDTO user)
        {
            if (!(caller.Login == user.Login ||
                  caller.Permissions.GetClubAdminPermissons<SocialEventDTO>().Any(t => t.Id == Id)))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<SocialEventDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void AddUserToSocialEvent(UserDTO caller, UserDTO userToAdd, int numberOfFriends)
        {
            NullCheck.ThrowArgumentNullEx(caller, userToAdd);
            CheckPermissionAllowSelfHandling(caller, userToAdd);
            if (userToAdd.Permissions.GetAttendancePermissions<SocialEventDTO>().Any(sePer => sePer.Id == Id))
            {
                userToAdd = userToAdd.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(userToAdd) ??
                    DbEntityAdder.AddUserToDb(userToAdd) : userToAdd;
                AddRelationToDb(CreateAttendancesRelation(userToAdd, numberOfFriends));
            }
            else
                throw new ArgumentException($"User: {userToAdd.Login} do not have permission to attend this socialevent");
        }

        public System.Collections.Generic.IEnumerable<UserDTO> GetParticipants()
        {
            return ServiceLocator.UserService.EagerDisconnectedService.FindBy(
                u => u.RegisteredUsers.Any(ru => ru.Entry.Regatta.SocialEvents.Any(se => se.Id == Id)));
        }

        public void RemoveUserFromSocialEvent(UserDTO caller, UserDTO userToRemove)
        {
            NullCheck.ThrowArgumentNullEx(caller, userToRemove);
            CheckPermissionAllowSelfHandling(caller, userToRemove);
            ValidateAction(userToRemove);

            RemoveAttendanceRelationFromDb(GetUserSocialEventRelation(userToRemove));
        }

        private void RemoveAttendanceRelationFromDb(RegisteredUsers_SocialEventsDTO relation)
        {
            ServiceLocator.RegisteredUserSocialEventService.Delete(relation);
        }

        private RegisteredUsers_SocialEventsDTO GetUserSocialEventRelation(UserDTO user)
        {
            return ServiceLocator.RegisteredUserSocialEventService.FindBy(
                uSeJunc => uSeJunc.RegisteredUser.UserId == user.Id && uSeJunc.SocialEvent.Id == Id).First();
        }

        private void ValidateAction(UserDTO userToRemove)
        {
            var participants = GetParticipants();
            if (participants.All(p => p.Id != userToRemove.Id))
                throw new ArgumentException($"Socialevent: {Name} Id: {Id} dose not contain a user {userToRemove.Login}");
        }

        private void AddRelationToDb(RegisteredUsers_SocialEventsDTO relation)
        {
            NullCheck.ThrowArgumentNullEx(relation);
            ServiceLocator.RegisteredUserSocialEventService.Add(relation);
        }

        private RegisteredUsers_SocialEventsDTO CreateAttendancesRelation(UserDTO user, int numberOfFriends)
        {
            var registeredUser = GetRegisteredUser(user);
            return new RegisteredUsers_SocialEventsDTO()
            {
                RegisteredUserId = registeredUser.UserId,
                SocialEventId = Id,
                NoOfFriends = numberOfFriends
            };
        }

        private static RegisteredUserDTO GetRegisteredUser(UserDTO user)
        {
            var registerUser = ServiceLocator.RegisteredUserService.FindBy(re => re.UserId == user.Id).FirstOrDefault();
            NullCheck.ThrowArgumentNullEx(registerUser);
            return registerUser;
        }
    }
}