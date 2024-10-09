using Blazor.UI.Data.ModelViews.Theater;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.UI.Data.Services.TheatherService
{
    public interface IPaymentService
    {
        Task<string> Checkout(int tikect,int price, PieceDto getpiece);
    }
    public class PaymentService : IPaymentService
    { 
        private readonly HttpClient _httpclient;
        private string ApiUri = "https://localhost:7170/api/v1/Stripe";

        public PaymentService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<string> Checkout(int tikect, int price, PieceDto getpiece)
        {
           var response= await _httpclient.PostAsJsonAsync<PieceDto>(ApiUri + $"/check-out/{tikect}/{price}",getpiece);
            var url= await response.Content.ReadAsStringAsync();
            return url;
        }
    }
}
