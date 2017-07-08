using Domain.Interfaces;
using Domain.Interfaces.Entities;
using Domain.Utilities.RoleHandlers;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class RegattaDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public int ClubId { get; set; }
        public int AddressId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public AddressDTO Address { get; private set; }
        public ClubDTO Club { get; private set; }
        public IRoleHandler RoleHandler => new RegattaRoleHandler(this);

        public RegattaDTO(string name, DateTime startDate, DateTime endDate, int fee, string description, int clubId, int addressId, string sa_Info = null)
        {
            ValidateInParameters(name, startDate, endDate, fee, clubId, addressId);

            Id = 0;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Fee = fee;
            Description = description;
            ClubId = clubId;
            AddressId = addressId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public RegattaDTO(IRegatta regatta)
        {
            if (regatta.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(regatta.Id)} cannot be less than 0.");
            ValidateInParameters(regatta.Name, regatta.StartDate, regatta.EndDate, regatta.Fee, regatta.Club.Id, regatta.Address.Id);
            AddressDTO address = new AddressDTO(regatta.Address);
            ClubDTO club = new ClubDTO(regatta.Club);
            
            Id = regatta.Id;
            Name = regatta.Name;
            StartDate = regatta.StartDate;
            EndDate = regatta.EndDate;
            Fee = regatta.Fee;
            Description = regatta.Description;
            ClubId = club.Id;
            AddressId = address.Id;
            Address = address;
            Club = club;
            Active = regatta.Active;
            this.sa_Info = regatta.sa_Info;
        }

        private void ValidateInParameters(string name, DateTime startDate, DateTime endDate, int fee, int clubId, int addressId)
        {
            // TODO: Implement validation!
        }

        public void CheckPermissionAllowSelfHandling(UserDTO caller, UserDTO user)
        {
            if (!(caller.Login == user.Login ||
                  caller.Permissions.GetClubAdminPermissons<RegattaDTO>().Any(t => t.Id == Id)))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<RegattaDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionToAffiliatedClub(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<ClubDTO>().All(t => t.Id != ClubId))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }
    }
}