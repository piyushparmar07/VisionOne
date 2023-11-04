using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.Core.Domain;

namespace VisionOne.BAL.Service.Interface
{
    public interface IUserService
    {
        User AuthenticateUser(string username, string password);
    }
}
