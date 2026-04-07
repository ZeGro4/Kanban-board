using Kanban_board.Models.Entities;
using Kanban_board.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Kanban_board.Models.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        protected ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var user = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null) throw new NullReferenceException();

            return user;
          
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser user) { 
        
            await _dbContext.ApplicationUsers.AddAsync(user);
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _dbContext.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user) { 
        
            _dbContext.Entry(user).State = EntityState.Modified;
            return user;
        }
    }
}
