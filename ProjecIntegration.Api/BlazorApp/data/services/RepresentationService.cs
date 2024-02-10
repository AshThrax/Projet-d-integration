using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.data.modelViews;

namespace BlazorApp.data.services
{
    public interface IRepresentationService : IHttpClient<RepresentationDto>
    {

    }
    public class RepresentationService : HttpClient<RepresentationDto>,
     IRepresentationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public RepresentationService(HttpClient httpClient,
        string apiBaseUrl)
        : base(httpClient, apiBaseUrl)
        {
            _httpClient = httpClient;
            _apiBaseUrl = apiBaseUrl;
        }

    }
}