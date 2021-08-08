﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserCredentialRepository : IBaseRepository<UserCredential>
    {
        Task<UserCredential> LoginUser(string email);
        Task<bool> ChangePassword(int id, string password);
        Task<bool> UpdateLastLogin(int id);
    }

    class UserCredentialRepository : BaseRepository<UserCredential>, IUserCredentialRepository
    {
        private readonly DbContext _context;

        public UserCredentialRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }

        #region Login

        public async Task<UserCredential> LoginUser(string email)
        {
            return await DbTable.Where(x => x.Email.Equals(email)).Include(l => l.User).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateLastLogin(int id)
        {
            var userCredential = await GetById(id);
            userCredential.LastLogin = DateTime.UtcNow;

            _context.Entry(userCredential).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Change Password

        public async Task<bool> ChangePassword(int id, string password)
        {
            var userCredential = await GetById(id);
            userCredential.Password = password;

            _context.Entry(userCredential).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion
    }
}