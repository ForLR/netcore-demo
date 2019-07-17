using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 用户管理.Data;
using 用户管理.Models;

namespace 用户管理.Repository
{
    public class UserRepository: IRepository<User>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User t)
        {
            await _context.AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }
        public Task DeleteAsync(User t)
        {
             _context.Remove(t);
            return _context.SaveChangesAsync();
        }
        public List<User> GetAll()
        {
            return  _context.Users.ToList();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
            
        }

        public  Task UpdateAsync(User t)
        {
            _context.Entry(t).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
