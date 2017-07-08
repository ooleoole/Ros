using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using System;

namespace Domain.Services.AggregatRoots.UserServices
{
    public class LazyConnectedUserService : BaseServices.LazyConnectedService<UserDTO, User>
    {
        public LazyConnectedUserService()
        {
        }

        public LazyConnectedUserService(ILazyConnectedRepository<User> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, UserDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            CheckPermission(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<User>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Add(UserDTO entity, UserDTO caller = null)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<User>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, UserDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            CheckPermission(caller, entity);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<User>(entity);
            _repo.Delete(entityToDelete);
        }

        private static void CheckPermission(UserDTO caller, UserDTO entity)
        {
            if (caller.Id != entity.Id)
                throw new ArgumentException(
                    $"Invalid operation. The caller of this metod do not have permission to perform this operation");
        }
    }
}