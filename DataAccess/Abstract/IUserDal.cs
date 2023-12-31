﻿using Core.Repository.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public Task<User> GetUser(LoginDto mode);
        public Task GenerateUserRefreshToken(int id, string refreshToken, DateTime tokenStartDate, DateTime tokenExpiredDate);
    }
}
