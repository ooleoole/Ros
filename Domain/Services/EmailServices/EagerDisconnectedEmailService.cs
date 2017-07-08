using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.EmailServices
{
    public class EagerDisconnectedEmailService : BaseServices.EagerDisconnectedService<EmailDTO, Email>
    {
        public EagerDisconnectedEmailService()
        {
        }

        public EagerDisconnectedEmailService(IEagerDisconnectedRepository<Email> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, EmailDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Email>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, EmailDTO entity, Expression<Func<IUpdateConfiguration<Email>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Email>(entity);
            _repo.Update(entityToUpdate, graph);
        }

        public override void Add(UserDTO caller, EmailDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Email>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, EmailDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Email>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}