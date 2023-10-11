using Core.Repository.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore
{
    public class EfUserDal : EfEntityRepository<User, MeetingMssqlDbContext>, IUserDal
    {
        public async Task GenerateUserRefreshToken(int id,string refreshToken,DateTime tokenStartDate, DateTime tokenExpiredDate)
        {
            using (var context=new MeetingMssqlDbContext())
            {
                var getUser = context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive).Result;
                if (getUser != null)
                {
                    getUser.RefreshToken = refreshToken;
                    getUser.TokenStartDate = tokenStartDate;
                    getUser.TokenExpiredDate = tokenExpiredDate;
                    await context.SaveChangesAsync();
                }
               
               
            }
        }

        public async Task<User>  GetUser(LoginDto model)
        {
            using (var context = new MeetingMssqlDbContext())
            {
                var getUser = context.Users.FirstOrDefaultAsync(x => x.EmailAddress == model.EmailAddress && x.Password == model.Password && x.IsActive==true);
                if (getUser == null)
                {
                    return null;
                }
                return await getUser;             
            }
        }
    }
}
