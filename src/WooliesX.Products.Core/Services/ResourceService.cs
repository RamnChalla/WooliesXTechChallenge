using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Config;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    public class ResourceService : IResourceService
    {
        private readonly HttpClient _client;
        private readonly AppConfig _config;

        public ResourceService(HttpClient client, IOptions<AppConfig> config)
        {
            _client = client;
            _config = config.Value;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            HttpResponseMessage httpResponse;
            try
            {
                var endpoint = $"{_config.BaseAddress}{_config.UrlPathBase}{_config.ProductEndpoint}";

                UriBuilder builder = new UriBuilder(endpoint)
                {
                    Query = $"token={_config.Token}"
                };
             
                httpResponse = await _client.GetAsync(builder.Uri).ConfigureAwait(false);                             
            }
            catch (Exception ex)
            {
                Log.Error($"Error Calling service Exception:{ex}");
                throw new Exception(ex.Message);
            }
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Product>>(responseString);
        }

        public async Task<List<ShopperHistory>> GetShopperHistoryAsync()
        {
            HttpResponseMessage httpResponse;
            try
            {
                var endpoint = $"{_config.BaseAddress}{_config.UrlPathBase}{_config.ShopperHistoryEndpoint}";

                UriBuilder builder = new UriBuilder(endpoint)
                {
                    Query = $"token={_config.Token}"
                };

                // return await _client.GetAsync<List<ShopperHistory>>(builder.Uri);
              httpResponse = await _client.GetAsync(builder.Uri);
              
            }
            catch (Exception ex)
            {
                Log.Error($"Error Calling service Exception:{ex}");
                throw new Exception(ex.Message);
            }
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ShopperHistory>>(responseString);
        }
    
        public async Task<decimal> GetTrolleyTotalAsync(TrolleyCalculatorEntity query)
        {
            var requestbody = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse;
            try
            {
                var endpoint = $"{_config.BaseAddress}{_config.UrlPathBase}{_config.TrolleyCalculatorEndpoint}";

                UriBuilder builder = new UriBuilder(endpoint)
                {
                    Query = $"token={_config.Token}"
                };

                httpResponse = await _client.PostAsync(builder.Uri, requestbody);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in posting service Exception:{ex}");
                throw new Exception(ex.Message);
            }
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<decimal>(responseString);
        }

    }
}
