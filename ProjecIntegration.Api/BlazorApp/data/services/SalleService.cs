using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.data.modelViews;

namespace BlazorApp.data.services
{
    public interface ISalleService : IHttpClient<SalleDeTheatreDto>

    {

    }
    public class SalleService : HttpClient<SalleDeTheatreDto>,
    ISalleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public SalleService(HttpClient httpClient, string apiBaseUrl) : base(httpClient, apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = httpClient;
        }
    }
}