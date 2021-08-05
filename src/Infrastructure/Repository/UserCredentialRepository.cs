using Application.DTOs.AuthenticationDTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IUserCredentialRepository : IBaseRepository<UserCredential>
    {
        Task<UserCredential> LoginUser(LoginRequestDTO loginRequestDTO);
        Task<bool> ChangePassword(int id, string password);
    }

    class UserCredentialRepository : BaseRepository<UserCredential>, IUserCredentialRepository
    {
        private readonly AppDbContext _context;

        public UserCredentialRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserCredential> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            return await DbTable.Where(x => x.Email.Equals(loginRequestDTO.Email) && x.Password.Equals(loginRequestDTO.Password)).Include(l => l.User).FirstOrDefaultAsync();
        }

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
