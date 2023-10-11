using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task GenerateUserRefreshToken(int id, string refreshToken, DateTime tokenStartDate, DateTime tokenExpiredDate)
        {
            await _userDal.GenerateUserRefreshToken(id, refreshToken, tokenStartDate, tokenExpiredDate);
        }

        public async Task<User> GetUser(LoginDto model)
        {
            var result = await _userDal.GetUser(model);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
