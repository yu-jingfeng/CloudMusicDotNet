using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly ICryptoService _cryptoService;
        private readonly IConfiguration _configuration;

        public RequestService(
            IHttpClientFactory clientFactory,
            ICryptoService cryptoService,
            IConfiguration configuration)
        {
            _httpClient = clientFactory.CreateClient("CloudMusic");
            _cryptoService = cryptoService;
            _configuration = configuration;
        }

        public async Task<string> Request(string apiName, string data, string queryString = "")
        {
            string body = string.Empty;
            var apiInfo = _configuration.GetSection(apiName).Get<ApiInfo>();

            if (apiInfo.Crypto == "weapi")
                body = _cryptoService.GetWeapiCrypto(data);
            else
                body = _cryptoService.GetLinuxapiCrypto(data);

            var content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient
                .PostAsync(apiInfo.Url + queryString, content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            if (result == "{\"msg\":null,\"code\":301}")
                result = "{\"msg\":\"需要登录\",\"code\":301}";

            return result;
        }
    }
}
