using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.BAL.Service.Interface;
using VisionOne.Core.Domain;
using VisionOne.DAL.Repository.Interface;

namespace VisionOne.BAL.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public string GetRoleById(int Id)
        {
            var obj = _roleRepository.GetById<Role>(Id).Result;
            if (obj != null)
                return obj.Name;
            else
                return string.Empty;
        }

        //public string GetRoleById(int Id)
        //{
        //    return _roleRepository.GetRoleById(Id);
        //}
    }
}
