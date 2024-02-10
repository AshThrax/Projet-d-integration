using Blazor.UI.modelViews;
using System.Net.Http.Json;

namespace Blazor.UI.services
{
    public interface IHttpClient<T> where T : Baseview
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> UpdateAsync(int id, T entity);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(int id);
    }
    public class HttpClient<T> : IHttpClient<T>
        where T : Baseview
    {
        private readonly HttpClient httpClient;
        private readonly string apiBaseUrl;

        public HttpClient(HttpClient httpClient, string apiBaseUrl)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.apiBaseUrl = apiBaseUrl ?? throw new ArgumentNullException(nameof(apiBaseUrl));
        }

        public async Task<T> GetAsync(int id)
        {
            var response = await httpClient.GetAsync($"{apiBaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await httpClient.GetAsync(apiBaseUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var response = await httpClient.PostAsJsonAsync(apiBaseUrl, entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var response = await httpClient.PutAsJsonAsync($"{apiBaseUrl}/{id}", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{apiBaseUrl}/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
