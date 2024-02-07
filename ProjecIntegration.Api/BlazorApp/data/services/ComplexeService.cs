using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.data.modelViews;

namespace BlazorApp.data.services
{
    public interface IComplexeService : IHttpClient<ComplexeDto>
    {

    }
    public class ComplexeService : HttpClient<ComplexeDto>, IComplexeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public ComplexeService(HttpClient httpClient, string apiBaseUrl)
                                : base(httpClient, apiBaseUrl)
        {
            _httpClient = httpClient;
            _apiBaseUrl = apiBaseUrl;
        }
    }
}