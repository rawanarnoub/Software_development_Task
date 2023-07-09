using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(
            DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users;
        }

        public Users GetById(int id)
        {
            return getUser(id);
        }

        public void Create(Users model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public void Update(int id, Users model)
        {
            var user = getUser(id);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private Users getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

    }
}
