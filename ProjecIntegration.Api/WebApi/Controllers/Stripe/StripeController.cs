using Domain.settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using WebApi.ApiService.PaymentService;

namespace WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StripeController : ControllerBase
    {
        private readonly ILogger<StripeController> _looger;
        private readonly IPaymentService _paymentService;
        public StripeController(ILogger<StripeController> logger, IPaymentService paymentService)
        {
            _paymentService= paymentService;
            _looger = logger;
        }
        [HttpPost("check-out/{ticketNumber}/{price}")]
        public ActionResult CreateCheckoutSession(int ticketNumber, int price,[FromBody]PieceDto getPiece)
        {
            var session = _paymentService.CreateSession(ticketNumber, price,  getPiece);
            return Ok(session.Url);
        }
    }
}
