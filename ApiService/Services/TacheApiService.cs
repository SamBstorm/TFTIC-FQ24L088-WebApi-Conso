using ApiService.Entities;
using ApiService.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public class TacheApiService : ITacheAsyncRepository
    {
        private Uri _api_uri;
        private readonly string _defaultRoute = "/api/Tache/";
        public TacheApiService(IConfiguration configuration)
        {
            _api_uri = new Uri(configuration.GetSection("URIs").GetSection("TaskManager").Value);
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = _api_uri;
            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            return http;
        }
        public async Task DeleteAsync(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                
                HttpResponseMessage response = await httpClient.DeleteAsync(_defaultRoute + id);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<IEnumerable<Tache>> GetAsync()
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(_defaultRoute);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IEnumerable<Tache>>();
            }
        }

        public async Task<Tache> GetAsync(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(_defaultRoute + id);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Tache>();
            }
        }

        public async Task<Tache> InsertAsync(Tache tache)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string json = JsonSerializer.Serialize(tache);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(_defaultRoute, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Tache>();
            }
        }

        public async Task UpdateAsync(int id, Tache tache)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string json = JsonSerializer.Serialize(tache);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync(_defaultRoute, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
