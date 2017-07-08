using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Utilities.RoleHandlers
{
    public abstract class RoleHandler : IRoleHandler
    {
        private readonly IPermissionTarget _target;

        protected RoleHandler(IPermissionTarget target)
        {
            _target = target;
        }

        public void AddRoleRelation(UserDTO caller, UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user);
            _target.CheckPermission(caller);
            user = user.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(user) ?? DbEntityAdder.AddUserToDb(user) : user;
            AddRoleRelationToDb(CreateRoleRelation(user, role));
        }

        public void AddRoleRelation(UserDTO caller, UserDTO user, EmailDTO email, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, email);
            _target.CheckPermission(caller);
            user = user.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(user) ?? DbEntityAdder.AddUserToDb(user) : user;
            email = email.Id == 0 ? DbEntityExistensChecker.TryGetExistingEmailFromDb(email) ?? DbEntityAdder.AddEmailToDb(email) : email;

            AddRoleRelationToDb(CreateRoleRelation(user, email, role));
        }

        public void AddRoleRelation(UserDTO caller, UserDTO user, PhoneNumberDTO phoneNumber, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, phoneNumber);
            _target.CheckPermission(caller);
            user = user.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(user) ?? DbEntityAdder.AddUserToDb(user) : user;
            phoneNumber = phoneNumber.Id == 0 ? DbEntityExistensChecker.TryGetExistingPhoneNumberFromDb(phoneNumber) ??
                DbEntityAdder.AddPhoneNumberToDb(phoneNumber) : phoneNumber;

            AddRoleRelationToDb(CreateRoleRelation(user, phoneNumber, role));
        }

        public void AddRoleRelation(UserDTO caller, UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, phoneNumber, email);
            _target.CheckPermission(caller);
            user = user.Id == 0 ? DbEntityExistensChecker.TryGetExistingUserFromDb(user) ?? DbEntityAdder.AddUserToDb(user) : user;
            phoneNumber = phoneNumber.Id == 0 ? DbEntityExistensChecker.TryGetExistingPhoneNumberFromDb(phoneNumber) ??
                                                DbEntityAdder.AddPhoneNumberToDb(phoneNumber) : phoneNumber;
            email = email.Id == 0 ? DbEntityExistensChecker.TryGetExistingEmailFromDb(email) ?? DbEntityAdder.AddEmailToDb(email) : email;

            AddRoleRelationToDb(CreateRoleRelation(user, phoneNumber, email, role));
        }

        public void RemoveRoleRelation(UserDTO caller, UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(caller, user, role);
            _target.CheckPermission(caller);
            RemoveRoleRelationFromDb(GetRoleRelation(user, role));
        }

        internal abstract IRoleJunction CreateRoleRelation(UserDTO user, Role role);

        internal abstract IRoleJunction CreateRoleRelation(UserDTO user, EmailDTO email, Role role);

        internal abstract IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, Role role);

        internal abstract IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role);

        internal abstract IRoleJunction GetRoleRelation(UserDTO user, Role role);

        internal abstract void RemoveRoleRelationFromDb(IRoleJunction relation);

        internal abstract void AddRoleRelationToDb(IRoleJunction relation);
    }
}