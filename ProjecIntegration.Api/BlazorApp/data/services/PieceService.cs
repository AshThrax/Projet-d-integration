using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.data.modelViews;

namespace BlazorApp.data.services
{
    public interface IPieceService : IHttpClient<PieceDto>
    {

    }

    public class PieceService : HttpClient<PieceDto>, IPieceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public PieceService(HttpClient httpClient, string apiBaseUrl)
                                        : base(httpClient, apiBaseUrl)
        {
            _httpClient = httpClient;
            _apiBaseUrl = apiBaseUrl;
        }
    }
}