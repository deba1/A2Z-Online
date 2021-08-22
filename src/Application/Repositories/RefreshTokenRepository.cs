using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string token);
        Task<int> Add(RefreshToken refreshToken);
        Task<int> Add(string refreshToken, int userId);
        Task<int> Update(RefreshToken refreshToken);
        Task<int> Remove(RefreshToken refreshToken);
    }
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DbContext _context;

        public RefreshTokenRepository(IAppDbContext dbContext) {
            _context = dbContext.Instance;
        }

        public async Task<int> Add(RefreshToken refreshToken)
        {
            refreshToken.CreatedAt = DateTime.UtcNow;
            _context.Set<RefreshToken>().Add(refreshToken);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Add(string refreshToken, int userId)
        {
            return await Add(new RefreshToken
            {
                Token = refreshToken,
                Invalidated = false,
                Used = false,
                JwtId = "",
                ExpiryDate = DateTime.MaxValue,
                UserId = userId
            });
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await _context.Set<RefreshToken>().Include(t => t.User).FirstOrDefaultAsync(t => t.Token.Equals(token));
        }

        public async Task<int> Remove(RefreshToken refreshToken)
        {
            _context.Set<RefreshToken>().Remove(refreshToken);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(RefreshToken refreshToken)
        {
            refreshToken.ModifiedAt = DateTime.UtcNow;
            _context.Entry(refreshToken).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
