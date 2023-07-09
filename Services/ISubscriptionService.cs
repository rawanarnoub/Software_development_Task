using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface ISubscriptionService
    {
        IEnumerable<Subscription> GetAll();
        Subscription GetById(int id);
        void Create(Subscription model);
        void Update(int id, Subscription model);
        void Delete(int id);
    }
}
