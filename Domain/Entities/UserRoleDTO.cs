using Domain.Interfaces.Entities;
using System;

namespace Domain.Entities
{
    public class UserRoleDTO
    {
        public int Id { get; private set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }

        public UserRoleDTO(string type, string sa_Info = null)
        {
            ValidateInParameters(type);

            Id = 0;
            Type = type;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public UserRoleDTO(IUserRoleDTO userRole)
        {
            if (userRole.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(userRole.Id)} cannot be less than 0.");
            ValidateInParameters(userRole.Type);

            Id = userRole.Id;
            Type = userRole.Type;
            Active = userRole.Active;
            sa_Info = userRole.sa_Info;
        }

        private void ValidateInParameters(string type)
        {
            // TODO: Implement validation!
        }
    }
}