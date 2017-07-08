using Domain.Entities.Junctions;
using Domain.Interfaces;
using Domain.Interfaces.Entities;
using Domain.Services.Locator;
using Domain.Utilities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class TeamDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public int TeamNo { get; set; }
        public string TeamName { get; set; }
        public int EntryId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public EntryDTO Entry { get; private set; }

        public TeamDTO(int teamNo, string teamName, int entryId, string sa_Info = null)
        {
            ValidateInParameters(teamNo, teamName, entryId);

            Id = 0;
            TeamNo = teamNo;
            TeamName = teamName;
            EntryId = entryId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public TeamDTO(ITeam team)
        {
            if (team.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(team.Id)} cannot be less than 0.");
            EntryDTO entry = new EntryDTO(team.Entry);
            ValidateInParameters(team.TeamNo, team.TeamName, team.Entry.Id);

            Id = team.Id;
            TeamNo = team.TeamNo;
            TeamName = team.TeamName;
            EntryId = team.Entry.Id;
            Entry = entry;
            Active = team.Active;
            sa_Info = team.sa_Info;
        }

        private void ValidateInParameters(int teamNo, string teamName, int entryId)
        {
            // TODO: Implement validation!
        }

        public System.Collections.Generic.IEnumerable<UserDTO> GetTeamMembers()
        {
            return ServiceLocator.UserService.EagerDisconnectedService.FindBy(
                u => u.RegisteredUsers.Any(re => re.Teams_RegisteredUsers.Any(tr => tr.TeamId == Id)));
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetEntryAdminPermissons<TeamDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionToAffiliatedEntry(UserDTO caller)
        {
            if (caller.Permissions.GetEntryAdminPermissons<EntryDTO>().All(t => t.Id != EntryId))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionAllowSelfHandling(UserDTO caller, UserDTO user)
        {
            if (!(caller.Login == user.Login ||
                 caller.Permissions.GetEntryAdminPermissons<TeamDTO>().Any(t => t.Id == Id)))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void AddUserToTeam(UserDTO caller, UserDTO userToAdd)
        {
            NullCheck.ThrowArgumentNullEx(caller, userToAdd);
            CheckPermissionAllowSelfHandling(caller, userToAdd);

            if (userToAdd.Permissions.GetTeamParticipationPermissions().Any(t => t.Id == Id))
            {
                userToAdd = userToAdd.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(userToAdd) ??
                    DbEntityAdder.AddUserToDb(userToAdd) : userToAdd;
                SaveRelationToDb(CreateRelation(userToAdd));
            }
            else
                throw new ArgumentException($"User: {userToAdd.Login} cannot be added to this team." +
                                            $"Make sure that the user is affiliated with an entry that holds this team");
        }

        public void RemoveUserFromTeam(UserDTO caller, UserDTO userToRemove)
        {
            NullCheck.ThrowArgumentNullEx(caller, userToRemove);
            CheckPermissionAllowSelfHandling(caller, userToRemove);
            ValidateAction(userToRemove);
            RemoveRelationFromDb(GetTeamUserRelation(userToRemove));
        }

        private void RemoveRelationFromDb(Teams_RegisteredUsersDTO relation)
        {
            ServiceLocator.TeamRegisteredUserService.Delete(relation);
        }

        private Teams_RegisteredUsersDTO GetTeamUserRelation(UserDTO user)
        {
            return ServiceLocator.TeamRegisteredUserService.FindBy(
                tReJunc => tReJunc.RegisteredUser.UserId == user.Id && tReJunc.TeamId == Id).First();
        }

        private void ValidateAction(UserDTO userToRemove)
        {
            var team = GetTeamMembers();
            if (team.All(u => u.Id != userToRemove.Id))
                throw new ArgumentException($"Team: {TeamName} Id: {Id} dose not contain a user {userToRemove.Login}");
        }

        private void SaveRelationToDb(Teams_RegisteredUsersDTO relation)
        {
            NullCheck.ThrowArgumentNullEx(relation);
            ServiceLocator.TeamRegisteredUserService.Add(relation);
        }

        private Teams_RegisteredUsersDTO CreateRelation(UserDTO user)
        {
            var registeredUser = GetRegisteredUser(user);

            return new Teams_RegisteredUsersDTO()
            {
                RegisteredUserId = registeredUser.Id,
                TeamId = Id
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