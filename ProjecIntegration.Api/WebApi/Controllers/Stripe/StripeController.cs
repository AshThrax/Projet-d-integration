using Domain.settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly ILogger<StripeController> _looger;
        private readonly StripeSettings _stripeSettings;
        public StripeController(ILogger<StripeController> logger, IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
            _looger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(string amount, int Quantity)
        {
            string currency = "eur";//currency
            string? sucessUrl = "https://localhost:7129/success";
            string? cancelUrl = "https://localhost:7129/cancel";
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                   {
                       "card"
                   },
                LineItems = new List<SessionLineItemOptions>
                   {
                       new SessionLineItemOptions
                       {
                           PriceData = new SessionLineItemPriceDataOptions
                           {
                               Currency = currency,
                               UnitAmount= Convert.ToInt32(amount),
                               ProductData= new SessionLineItemPriceDataProductDataOptions
                               {
                                   Name="PIéce de théatre",
                                   Description="nom de la pièce ?"
                               },
                           },
                           Quantity=Quantity
                       }

                   },
                Mode = "payment",
                SuccessUrl = sucessUrl,
                CancelUrl = cancelUrl
            };

            var service = new Stripe.Checkout.SessionService();
            var session = service.Create(options);


            return Ok(session.Url);
        }
    }
}
