using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services.BaseServices;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.BoatServices
{
    public class EagerDisconnectedClubService : EagerDisconnectedService<BoatDTO, Boat>
    {
        public EagerDisconnectedClubService()
        {
        }

        public EagerDisconnectedClubService(IEagerDisconnectedRepository<Boat> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, BoatDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Boat>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, BoatDTO entity, Expression<Func<IUpdateConfiguration<Boat>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Boat>(entity);
            _repo.Update(entityToUpdate, graph);
        }

        public override void Add(UserDTO caller, BoatDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Boat>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, BoatDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Boat>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}