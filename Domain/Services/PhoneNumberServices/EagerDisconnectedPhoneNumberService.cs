using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.PhoneNumberServices
{
    public class EagerDisconnectedPhoneNumberService : BaseServices.EagerDisconnectedService<PhoneNumberDTO, PhoneNumber>
    {
        public EagerDisconnectedPhoneNumberService()
        {
        }

        public EagerDisconnectedPhoneNumberService(IEagerDisconnectedRepository<PhoneNumber> repo) : base(repo)
        {
        }

        public override void Add(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Delete(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Delete(entityToDelete);
        }

        public override void Update(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, PhoneNumberDTO entity, Expression<Func<IUpdateConfiguration<PhoneNumber>, object>> graph)
        {
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Update(entityToUpdate, graph);
        }
    }
}