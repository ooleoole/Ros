using System.Collections.Generic;
using Domain.Entities.Junctions;
using Domain.Interfaces;
using Domain.Interfaces.Entities;
using Domain.Services.Locator;
using Domain.Utilities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class EntryDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public int EntryNo { get; set; }
        public string EntryName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int PaidAmount { get; set; }
        public int BoatId { get; set; }
        public int ResponsibleUserId { get; internal set; }
        public int RegattaId { get; set; }
        public int? ClubRepresentationId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public BoatDTO Boat { get; private set; }
        public ClubDTO Club { get; private set; }
        public UserDTO User { get; private set; }
        public RegattaDTO Regatta { get; private set; }
        

        public EntryDTO(int entryNo, string entryName, DateTime registrationDate, int paidAmount, int boatId, int responsibleUserId, int regattaId, int? clubRepresentationId = null, string sa_Info = null)
        {
            ValidateInParameters(entryNo, entryName, registrationDate, paidAmount, boatId, responsibleUserId, clubRepresentationId);

            Id = 0;
            EntryNo = entryNo;
            EntryName = entryName;
            RegistrationDate = registrationDate;
            PaidAmount = paidAmount;
            BoatId = boatId;
            ResponsibleUserId = responsibleUserId;
            RegattaId = regattaId;
            ClubRepresentationId = clubRepresentationId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public EntryDTO(int entryNo, string entryName, DateTime registrationDate, int paidAmount, int boatId, int regattaId, int? clubRepresentationId = null, string sa_Info = null)
        {
            ValidateInParameters(entryNo, entryName, registrationDate, paidAmount, boatId, clubRepresentationId);

            Id = 0;
            EntryNo = entryNo;
            EntryName = entryName;
            RegistrationDate = registrationDate;
            PaidAmount = paidAmount;
            BoatId = boatId;
            ClubRepresentationId = clubRepresentationId;
            RegattaId = regattaId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public EntryDTO(IEntry entry)
        {
            if (entry.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(entry.Id)} cannot be less than 0.");
            ValidateInParameters(entry.EntryNo, entry.EntryName, entry.RegistrationDate, entry.PaidAmount, entry.Boat.Id, entry.User.Id, entry.Club.Id);
            var boat = new BoatDTO(entry.Boat);
            var club = new ClubDTO(entry.Club);
            var user = new UserDTO(entry.User);
            var regatta = new RegattaDTO(entry.Regatta);

            Id = entry.Id;
            EntryNo = entry.EntryNo;
            EntryName = entry.EntryName;
            RegistrationDate = entry.RegistrationDate;
            PaidAmount = entry.PaidAmount;
            BoatId = entry.Boat.Id;
            ResponsibleUserId = entry.User.Id;
            ClubRepresentationId = entry.Club.Id;
            RegattaId = entry.Regatta.Id;
            Boat = boat;
            Regatta = Regatta;
            Club = club;
            User = user;
            Regatta = regatta;
            Active = entry.Active;
            sa_Info = entry.sa_Info;
        }

        public IEnumerable<UserDTO> GetEntryMembers()
        {
            return ServiceLocator.UserService.InternalService.FindBy(
                u => u.RegisteredUsers.Any(re => re.EntryId == Id));
        }

        private void ValidateInParameters(int entryNo, string entryName, DateTime registrationDate, int paidAmount, int boatId, int responsibleUserId, int? clubRepresentationId)
        {
            // TODO: Implement validation!
        }

        private void ValidateInParameters(int entryNo, string entryName, DateTime registrationDate, int paidAmount, int boatId, int? clubRepresentationId)
        {
            // TODO: Implement validation!
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetEntryAdminPermissons<EntryDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }

        public void CheckPermissionAllowSelfHandling(UserDTO caller, UserDTO user)
        {
            if (!(caller.Login == user.Login ||
                 caller.Permissions.GetEntryAdminPermissons<EntryDTO>().Any(t => t.Id == Id)))
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }
        
        public void AddUserToEntry(UserDTO caller, UserDTO userToAdd)
        {
            NullCheck.ThrowArgumentNullEx(userToAdd);
            CheckPermissionAllowSelfHandling(caller, userToAdd);
            userToAdd = userToAdd.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(userToAdd) ??
                DbEntityAdder.AddUserToDb(userToAdd) : userToAdd;
            AddRelationToDb(GetRelation(userToAdd));
        }

        private void AddRelationToDb(RegisteredUserDTO relation)
        {
            NullCheck.ThrowArgumentNullEx(relation);
            ServiceLocator.RegisteredUserService.Add(relation);
        }

        private RegisteredUserDTO GetRelation(UserDTO user)
        {
            return new RegisteredUserDTO()
            {
                UserId = user.Id,
                EntryId = Id
            };
        }
    }
}