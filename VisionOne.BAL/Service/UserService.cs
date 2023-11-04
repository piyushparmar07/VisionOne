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
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string username, string password)
        {
          return _userRepository.FindQueryable<User>(expression: m => m.Email == username && m.Password == password).FirstOrDefault();
        }

        //public async Task<IEnumerable<Use>> getuser()
        //{
        //    return await _context.UserLogin.ToListAsync();
        //}
    }
}
