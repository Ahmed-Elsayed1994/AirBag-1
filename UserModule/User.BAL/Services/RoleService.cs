using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using User.BAL.Models;

namespace User.BAL.Services
{
    public class RoleService : BaseService<CoreData.Users.Entities.Role,RoleVm> , IRoleService
    {
        private readonly IUtility _utility;
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> repository, IUnitOfWork unitOfWork , IUtility utility) : base(repository, unitOfWork)
        {
            _utility = utility;
            _roleRepository = repository;
        }

        public override Role MapModelToEntity(RoleVm model)
        {
            if (model == null) return null;
            return new Role
            {
                Id = model.Id,
                Name = model.Name
            };

        }

        public override RoleVm MapEntityToModel(Role entity)
        {
            if (entity == null) return null;
            return new RoleVm
            {
                Name = entity.Name,
                Id = entity.Id
            };
        }

        protected override Func<Role, IVM> FuncToVM()
        {
            return (r) => new RoleVm
            {
                Id = r.Id,
                Name = r.Name
            };
        }

        protected override void ValidateUpdate(RoleVm model)
        {
            var match = _repository.SingleAsync(r => r.Id == model.Id,false);
            if (match == null) AddError(CommonErrors.NOT_FOUND);
        }

        public IList<Role> GetRolesByIds(IList<int> RolesId)
        {
            if (RolesId == null || RolesId.Count == 0)
                return null;

            return _roleRepository.Table.Where(a => RolesId.Contains(a.Id)).ToList();
        }

        public IList<Role> GetRoles()
        {
            return _repository.GetAll().ToList();
        }
    }
}