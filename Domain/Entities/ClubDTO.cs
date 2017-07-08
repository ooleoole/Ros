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
    public class ClubDTO : IPermissionTarget, IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Logo { get; set; }
        public string HomePage { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public AddressDTO Address { get; private set; }
        public RoleHandler RoleHandler => new ClubRoleHandler(this);

        public ClubDTO(string name, int addressId, string logo, string homePage, string description, string sa_Info = null)
        {
            DateTime registrationDate = DateTime.Now;
            ValidateInParameters(name, registrationDate, addressId, logo, homePage, description);

            Id = 0;
            Name = name;
            RegistrationDate = registrationDate;
            Logo = logo;
            HomePage = homePage;
            Description = description;
            AddressId = addressId;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public ClubDTO(IClub club)
        {
            if (club.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(club.Id)} cannot be less than 0.");
            ValidateInParameters(club.Name, club.RegistrationDate, club.Address.Id, club.Logo, club.HomePage, club.Description);
            AddressDTO address = new AddressDTO(club.Address);

            Id = club.Id;
            Name = club.Name;
            RegistrationDate = club.RegistrationDate;
            Logo = club.Logo;
            HomePage = club.HomePage;
            Description = club.Description;
            AddressId = club.Address.Id;
            Address = address;
            Active = true;
            sa_Info = club.sa_Info;
        }

        private void ValidateInParameters(string name, DateTime registrationDate, int addressId, string logo, string homePage, string description)
        {
            
        }

        public System.Collections.Generic.IEnumerable<PhoneNumberDTO> GetPhoneNumbers()
        {
            return ServiceLocator.PhoneNumberService.EagerDisconnectedService.FindBy(
                p => p.Clubs_PhoneNumbers.Any(cp => cp.ClubId == Id));
        }

        public System.Collections.Generic.IEnumerable<EmailDTO> GetEmails()
        {
            return ServiceLocator.EmailService.EagerDisconnectedService.FindBy(
                e => e.Clubs_Emails.Any(ce => ce.ClubId == Id));
        }

        public void AddPhoneNumberToClub(UserDTO caller, PhoneNumberDTO phoneNumber)
        {
            NullCheck.ThrowArgumentNullEx(caller, phoneNumber);
            CheckPermission(caller);
            phoneNumber = phoneNumber.Id == 0 ? DbEntityExistensChecker.TryGetExistingPhoneNumberFromDb(phoneNumber) ??
                          DbEntityAdder.AddPhoneNumberToDb(phoneNumber) : phoneNumber;
            SaveRelationToDb(CreateRelation(phoneNumber));
        }

        public void AddEmailToClub(UserDTO caller, EmailDTO email)
        {
            NullCheck.ThrowArgumentNullEx(caller, email);
            CheckPermission(caller);
            email = email.Id == 0 ? DbEntityExistensChecker.TryGetExistingEmailFromDb(email) ?? DbEntityAdder.AddEmailToDb(email) : email;
            SaveRelationToDb(CreateRelation(email));
        }

        public void RemoveEmailFromClub(UserDTO caller, EmailDTO email)
        {
            NullCheck.ThrowArgumentNullEx(caller, email);
            CheckPermission(caller);
            RemoveRelationFromDb(GetRelation(email));
        }

        public void RemovePhoneNumberFromClub(UserDTO caller, PhoneNumberDTO phoneNumber)
        {
            NullCheck.ThrowArgumentNullEx(caller, phoneNumber);
            CheckPermission(caller);
            RemoveRelationFromDb(GetRelation(phoneNumber));
        }

        public void CheckPermission(UserDTO caller)
        {
            if (caller.Permissions.GetClubAdminPermissons<ClubDTO>().All(t => t.Id != Id))
                throw new ArgumentException(
                    $"Invalid operation. The caller do not have permission to perform this operation");
        }

        private Clubs_PhoneNumbersDTO GetRelation(PhoneNumberDTO phoneNumber)
        {
            phoneNumber = phoneNumber.Id == 0 ? DbEntityExistensChecker.TryGetExistingPhoneNumberFromDb(phoneNumber) : phoneNumber;
            return ServiceLocator.ClubsPhoneNumbersService.FindBy(
                    cpJunc => cpJunc.ClubId == Id && cpJunc.PhoneNumberId == phoneNumber.Id)
                .First();
        }

        private Clubs_EmailsDTO GetRelation(EmailDTO email)
        {
            email = email.Id == 0 ? DbEntityExistensChecker.TryGetExistingEmailFromDb(email) : email;
            return ServiceLocator.ClubsEmailsService.FindBy(
                    ceJunc => ceJunc.ClubId == Id && ceJunc.EmailId == email.Id)
                .First();
        }

        private void RemoveRelationFromDb(Clubs_PhoneNumbersDTO relation)
        {
            ServiceLocator.ClubsPhoneNumbersService.Delete(relation);
        }

        private void RemoveRelationFromDb(Clubs_EmailsDTO relation)
        {
            ServiceLocator.ClubsEmailsService.Delete(relation);
        }

        private Clubs_PhoneNumbersDTO CreateRelation(PhoneNumberDTO phoneNumber)
        {
            return new Clubs_PhoneNumbersDTO()
            {
                ClubId = Id,
                PhoneNumberId = phoneNumber.Id
            };
        }

        private Clubs_EmailsDTO CreateRelation(EmailDTO email)
        {
            return new Clubs_EmailsDTO()
            {
                ClubId = Id,
                EmailId = email.Id
            };
        }

        private void SaveRelationToDb(Clubs_PhoneNumbersDTO relation)
        {
            ServiceLocator.ClubsPhoneNumbersService.Add(relation);
        }

        private void SaveRelationToDb(Clubs_EmailsDTO relation)
        {
            ServiceLocator.ClubsEmailsService.Add(relation);
        }
    }
}