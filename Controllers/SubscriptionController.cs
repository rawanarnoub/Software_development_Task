using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication4.Logging;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubscriptionController : ControllerBase
    {


        public ISubscriptionService _SubscriptionService { get; set; }
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _SubscriptionService = subscriptionService;
        }
        [Authorize(Policy = "testAuthorization2")]
        [HttpGet]
        [Route("GetSubscription")]
        public IActionResult GetSubscription([FromQuery] int subscrinberId)
        {
            return Ok(subscrinberId);
        }
        [HttpPost]
        [Route("CreateSubscription")]
        public IActionResult AddSubscription(Subscription subscriptions)
        {
            try
            {
                _SubscriptionService.Create(subscriptions);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.logInfo(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //throw new NotImplementedException();
                var subscription = _SubscriptionService.GetAll();
                return Ok(subscription);
            }
            catch (Exception ex)
            {
                Log.logInfo(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subscription = _SubscriptionService.GetById(id);
            return Ok(subscription);
        }

        [HttpPost]
        public IActionResult Create(Subscription model)
        {
            _SubscriptionService.Create(model);
            return Ok(new { message = "Subscription created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Subscription model)
        {
            _SubscriptionService.Update(id, model);
            return Ok(new { message = "Subscription updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _SubscriptionService.Delete(id);
            return Ok(new { message = "Subscription deleted" });
        }
    }

}