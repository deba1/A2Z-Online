using Application.Interfaces.DBContextInterfaces;
using Application.Services.JwtServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string token);
        Task<int> Add(RefreshToken refreshToken);
        Task<int> Add(string refreshToken, int userId, DateTime? expiredAt = null);
        Task<int> Update(RefreshToken refreshToken);
        Task<int> Remove(RefreshToken refreshToken);
    }
    class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IAppDbContext _context;
        private readonly IJwtConfigurationServiceModel _jwtConfigurationServiceModel;

        public RefreshTokenRepository(IAppDbContext context, IJwtConfigurationServiceModel jwtConfigurationServiceModel)
        {
            _context = context;
            _jwtConfigurationServiceModel = jwtConfigurationServiceModel;
        }

        private DbSet<RefreshToken> DbTable => _context.Instance.Set<RefreshToken>();

        public async Task<int> Add(RefreshToken refreshToken)
        {
            refreshToken.CreatedAt = DateTime.UtcNow;
            DbTable.Add(refreshToken);
            return await _context.Instance.SaveChangesAsync();
        }

        public async Task<int> Add(string refreshToken, int userId, DateTime? expiredAt = null)
        {
            return await Add(new RefreshToken
            {
                Token = refreshToken,
                Invalidated = false,
                Used = false,
                JwtId = Guid.NewGuid().ToString(),
                ExpiryDate = expiredAt ?? DateTime.UtcNow.Add(_jwtConfigurationServiceModel.RefreshTokenValidationTime),
                UserId = userId
            });
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await DbTable.FirstOrDefaultAsync(t => t.Token.Equals(token));
        }

        public async Task<int> Remove(RefreshToken refreshToken)
        {
            DbTable.Remove(refreshToken);
            return await _context.Instance.SaveChangesAsync();
        }

        public async Task<int> Update(RefreshToken refreshToken)
        {
            refreshToken.ModifiedAt = DateTime.UtcNow;
            _context.Instance.Entry(refreshToken).State = EntityState.Modified;
            return await _context.Instance.SaveChangesAsync();
        }
    }
}
