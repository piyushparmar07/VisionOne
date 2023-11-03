using System;
using VisionOne.DAL.Data;

namespace VisionOne.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        VisionOneDataContext Init();
       
    }
    public interface IConnectionString
    {
        string MyConnection();
    }
}
