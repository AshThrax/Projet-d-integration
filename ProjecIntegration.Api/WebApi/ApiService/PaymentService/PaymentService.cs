
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

        public Session CreateSession(int ticketNumber, int price, PieceDto getPiece)
        {
            var lineItems = new List<SessionLineItemOptions>() 
            {
                new SessionLineItemOptions
                {
                    PriceData =new SessionLineItemPriceDataOptions 
                    {
                        UnitAmount = price*100,
                        Currency ="eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name= getPiece.Titre,
                            Images= new List<string> { $"https://localhost:7170/Resources/{getPiece?.Image}" }
                        },
                    },
                    Quantity=ticketNumber,
                }
            };

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes=new List<string> 
                {
                    "card",
                },
                LineItems =lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7129/paymentsuccess",
                CancelUrl = "https://localhost:7129/paymentcancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }
    }
}
