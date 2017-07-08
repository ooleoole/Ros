using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.AggregatRoots.UserServices
{
    public class EagerDisconnectedUserService : BaseServices.EagerDisconnectedService<UserDTO, User>
    {
        public EagerDisconnectedUserService()
        {
        }

        public EagerDisconnectedUserService(IEagerDisconnectedRepository<User> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, UserDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            CheckPermission(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<User>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, UserDTO entity, Expression<Func<IUpdateConfiguration<User>, object>> graph)
        {
            CheckPermission(caller, entity);

            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<User>(entity);
            _repo.Update(entityToUpdate, graph);
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