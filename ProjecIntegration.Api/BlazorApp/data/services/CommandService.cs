using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.data.modelViews;

namespace BlazorApp.data.services
{
    public interface ICommandService : IHttpClient<CommandDto>
    {

    }
    public class CommandService : HttpClient<CommandDto>,
     ICommandService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public CommandService(HttpClient httpClient,
            string apiBaseUrl) : base(httpClient, apiBaseUrl)
        {
            _httpClient = httpClient;
            _apiBaseUrl = apiBaseUrl;
        }

    }
}