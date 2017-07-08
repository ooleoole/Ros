using Domain.Interfaces;
using Domain.Interfaces.Entities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class BoatDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public int SailNo { get; internal set; }
        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public string Handicap { get; internal set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }

        public BoatDTO(int sailNo, string name, string type, string handicap, string sa_Info = null)
        {
            ValidateInParameters(sailNo, name, type, handicap);

            Id = 0;
            SailNo = sailNo;
            Name = name;
            Type = type;
            Handicap = handicap;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public BoatDTO(IBoat boat)
        {
            if (boat.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(boat.Id)} cannot be less than 0.");
            ValidateInParameters(boat.SailNo, boat.Name, boat.Type, boat.Handicap);

            Id = boat.Id;
            SailNo = boat.SailNo;
            Name = boat.Name;
            Type = boat.Type;
            Handicap = boat.Handicap;
            Active = boat.Active;
            sa_Info = boat.sa_Info;
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetEntryAdminPermissons<BoatDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionToAffiliatedEntry(UserDTO caller)
        {
            if (caller.Permissions.GetEntryAdminPermissons<EntryDTO>().All(t => ((EntryDTO)t).BoatId != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        private void ValidateInParameters(int sailNo, string name, string type, string handicap)
        {
            // TODO: Implement validation!
        }
    }
}