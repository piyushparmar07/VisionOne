using Microsoft.EntityFrameworkCore;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public User AuthenticateUser(string username, string password)
        {
            var objUser = _userRepository.FindQueryable<User>(expression: m => m.Email == username && m.Password == password).FirstOrDefault();
            if (objUser != null)
            {
                objUser.Role = new();
                var objRole = _roleRepository.FindQueryable<Role>(expression: m => m.Id == objUser.RoleId).FirstOrDefault();
                if (objRole != null)
                {
                    objUser.Role = objRole;
                }
            }
            return objUser;
        }

        //public async Task<IEnumerable<Use>> getuser()
        //{
        //    return await _context.UserLogin.ToListAsync();
        //}
    }
}
