using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<User> GetUser(LoginDto model);

        public Task GenerateUserRefreshToken(int id, string refreshToken, DateTime tokenStartDate, DateTime tokenExpiredDate);
    }
}
