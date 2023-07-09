using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IUserService
    {

        IEnumerable<Users> GetAll();
        Users GetById(int id);
        void Create(Users model);
        void Update(int id, Users model);
        void Delete(int id);
    }
}
