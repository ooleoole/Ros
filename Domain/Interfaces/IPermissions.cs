using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Utilities
{
    public interface IPermissions
    {
        IEnumerable<IPermissionTarget> GetClubAdminPermissons<TPermissionTarget>() where TPermissionTarget : IPermissionTarget;

        IEnumerable<IPermissionTarget> GetMemberships();

        IEnumerable<IPermissionTarget> GetAttendancePermissions<TEntity>() where TEntity : IPermissionTarget;

        IEnumerable<IPermissionTarget> GetEntryAdminPermissons<TPermissionTarget>() where TPermissionTarget : IPermissionTarget;

        IEnumerable<IPermissionTarget> GetTeamParticipationPermissions();

        IEnumerable<IPermissionTarget> GetRaceEventRegistrationPermissions();
    }
}