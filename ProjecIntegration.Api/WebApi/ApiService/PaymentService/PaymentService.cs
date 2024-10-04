
using Azure;
using Stripe;
using Stripe.Checkout;

namespace WebApi.ApiService.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51PH98ZP7zrjxHIPVeUJsRJSjWqAhRglJR1FTndQvN9yHnoQ9430NxZiPPvDWxqpe53QbQc21yEpKCnSXBSVfTDPx00eB1CmwjS";
        }

        public Session CreateSession(CommandDto command)
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = 2000,
                      Currency = "usd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = "T-shirt",
                      },
                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:7129/success",
                CancelUrl = "http://localhost:7129/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }
    }
}
