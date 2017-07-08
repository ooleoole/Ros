using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Locator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Utilities
{
    public class Permissions : IPermissions
    {
        private readonly UserDTO _user;
        private readonly int _adminRoleId = 1;
        private readonly int _memberRoleId = 3;

        public Permissions(UserDTO user)
        {
            _user = user;
        }

        public IEnumerable<IPermissionTarget> GetClubAdminPermissons<TPermissionTarget>() where TPermissionTarget : IPermissionTarget
        {
            var type = typeof(TPermissionTarget);

            if (type == typeof(ClubDTO))
                return GetAdminAffiliatedClubs();
            if (type == typeof(RegattaDTO))
                return GetAdminAffiliatedRegattas();
            if (type == typeof(RaceEventDTO))
                return GetAdminAffiliatedRaceEvents();
            if (type == typeof(SocialEventDTO))
                return GetAdminAffiliatedSocialEvents();
            if (type == typeof(ResultDTO))
                return GetAdminAffiliatedResults();

            throw new ArgumentException($"Invalid Target. PermissonTarget must be of Type: " +
                                        $"{typeof(ClubDTO)}, {typeof(RegattaDTO)}, {typeof(SocialEventDTO)}, {typeof(RaceEventDTO)} or {typeof(ResultDTO)} ");
        }

        public IEnumerable<IPermissionTarget> GetEntryAdminPermissons<TPermissionTarget>() where TPermissionTarget : IPermissionTarget
        {
            var type = typeof(TPermissionTarget);

            if (type == typeof(EntryDTO))
                return GetAdminAffiliatedEntries();
            if (type == typeof(BoatDTO))
                return GetAdminAffiliatedBoats();
            if (type == typeof(TeamDTO))
                return GetAdminAffiliatedTeams();

            throw new ArgumentException($"Invalid Target. PermissonTarget must be of Type: " +
                                        $"{typeof(EntryDTO)}, {typeof(BoatDTO)} or {typeof(TeamDTO)}");
        }

        public IEnumerable<IPermissionTarget> GetAttendancePermissions<TEntity>() where TEntity : IPermissionTarget
        {
            var type = typeof(TEntity);

            if (type == typeof(SocialEventDTO))
                return GetSocialEventAttendance();
            if (type == typeof(RaceEventDTO))
                return GetRaceEventAttendance();

            throw new ArgumentException($"Invalid Target. IPermisson must be of Type: " +
                                        $"{typeof(SocialEventDTO)} or {typeof(RaceEventDTO)} ");
        }

        public IEnumerable<IPermissionTarget> GetTeamParticipationPermissions()
        {
            return ServiceLocator.TeamService.EagerDisconnectedService.FindBy(t => t.Entry.RegisteredUsers.Any
                (ru => ru.Id == _user.Id || t.Entry.ResponsibleUserId == _user.Id));
        }

        public IEnumerable<IPermissionTarget> GetRaceEventRegistrationPermissions()
        {
            return GetRaceEventsByResponsible();
        }

        public IEnumerable<IPermissionTarget> GetMemberships()
        {
            var memberships = GetClubMemberships();
            var adminMemberships = GetAdminAffiliatedClubs();

            return adminMemberships.Union(memberships);
        }

        private IEnumerable<ResultDTO> GetAdminAffiliatedResults()
        {
            return ServiceLocator.ResultService.EagerDisconnectedService.FindBy(
                r => r.RaceEvent.Regatta.Club.Clubs_Users_UserRoles_Junctions.Any(
                    urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _adminRoleId));
        }

        private IEnumerable<TeamDTO> GetAdminAffiliatedTeams()
        {
            return ServiceLocator.TeamService.EagerDisconnectedService.FindBy(
                t => t.Entry.ResponsibleUserId == _user.Id);
        }

        private IEnumerable<BoatDTO> GetAdminAffiliatedBoats()
        {
            return ServiceLocator.BoatService.EagerDisconnectedService.FindBy(
                b => b.Entries.Any(e => e.ResponsibleUserId == _user.Id));
        }

        private IEnumerable<EntryDTO> GetAdminAffiliatedEntries()
        {
            return ServiceLocator.EntryService.EagerDisconnectedService.FindBy(
                e => e.ResponsibleUserId == _user.Id);
        }

        private IEnumerable<RaceEventDTO> GetRaceEventAttendance()
        {
            var raceEventAttendanceByRegisterUser = GetRaceEventsByRegisterUser();
            var raceEventAttendanceByResponsible = GetRaceEventsByResponsible();

            return raceEventAttendanceByResponsible.Union(raceEventAttendanceByRegisterUser);
        }

        private IEnumerable<RaceEventDTO> GetRaceEventsByResponsible()
        {
            return ServiceLocator.RaceEventService.EagerDisconnectedService.FindBy(
                re => re.Regatta.Entries.Any(
                    e => e.ResponsibleUserId == _user.Id));
        }

        private IEnumerable<RaceEventDTO> GetRaceEventsByRegisterUser()
        {
            return ServiceLocator.RaceEventService.EagerDisconnectedService.FindBy(
                re => re.Regatta.Entries.Any(
                    e => e.RegisteredUsers.Any(
                        ru => ru.Id == _user.Id)));
        }

        private IEnumerable<SocialEventDTO> GetSocialEventAttendance()
        {
            var socialEventAttendanceByRegisterUser = GetSocialEventAttendanceByRegisteredUser();
            var socialEventAttendanceByResponsible = GetSocialEventAttendanceByResponsible();

            return socialEventAttendanceByResponsible.Union(socialEventAttendanceByRegisterUser);
        }

        private IEnumerable<SocialEventDTO> GetSocialEventAttendanceByResponsible()
        {
            return ServiceLocator.SocialEventService.EagerDisconnectedService.FindBy(
                se => se.Regatta.Entries.Any(
                    e => e.ResponsibleUserId == _user.Id));
        }

        private IEnumerable<SocialEventDTO> GetSocialEventAttendanceByRegisteredUser()
        {
            return ServiceLocator.SocialEventService.EagerDisconnectedService.FindBy(
                se => se.Regatta.Entries.Any(
                    e => e.RegisteredUsers.Any(
                        ru => ru.Id == _user.Id)));
        }

        private IEnumerable<ClubDTO> GetAdminAffiliatedClubs()
        {
            return ServiceLocator.ClubService.EagerDisconnectedService.FindBy(
                c => c.Clubs_Users_UserRoles_Junctions.Any(
                    urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _adminRoleId));
        }

        private IEnumerable<RegattaDTO> GetAdminAffiliatedRegattas()
        {
            return ServiceLocator.RegattaService.EagerDisconnectedService.FindBy(
                r => r.Club.Clubs_Users_UserRoles_Junctions.Any(
                    urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _adminRoleId));
        }

        private IEnumerable<RaceEventDTO> GetAdminAffiliatedRaceEvents()
        {
            return ServiceLocator.RaceEventService.EagerDisconnectedService.FindBy(
                re => re.Regatta.Club.Clubs_Users_UserRoles_Junctions.Any(
                    urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _adminRoleId));
        }

        private IEnumerable<SocialEventDTO> GetAdminAffiliatedSocialEvents()
        {
            return ServiceLocator.SocialEventService.EagerDisconnectedService.FindBy(
                so => so.Regatta.Club.Clubs_Users_UserRoles_Junctions.Any(
                    urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _adminRoleId));
        }

        private IEnumerable<ClubDTO> GetClubMemberships()
        {
            return ServiceLocator.ClubService.EagerDisconnectedService.FindBy(
                c => c.Clubs_Users_UserRoles_Junctions.Any(
                urJunc => urJunc.UserId == _user.Id && urJunc.UserRole.Id == _memberRoleId));
        }
    }
}