using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private DataContext _context;

        public SubscriptionService(
            DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _context.Subscription;
        }

        public Subscription GetById(int id)
        {
            return getSubscription(id);
        }

        public void Create(Subscription model)
        {
            _context.Subscription.Add(model);
            _context.SaveChanges();
        }

        public void Update(int id, Subscription model)
        {
            var subscription = getSubscription(id);
            _context.Subscription.Update(subscription);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscription = getSubscription(id);
            _context.Subscription.Remove(subscription);
            _context.SaveChanges();
        }

        // helper methods

        private Subscription getSubscription(int id)
        {
            var subscription = _context.Subscription.Find(id);
            if (subscription == null) throw new KeyNotFoundException("Subscription not found");
            return subscription;
        }
    }
}
