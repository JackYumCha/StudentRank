using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcAngular;
using RankAPI.Dtos;
using System.Net.Http;
using Newtonsoft.Json;
using Serilog;

namespace RankAPI.Controllers
{
    [Angular, Route("[controller]/[action]")]
    public class ProxyController : Controller
    {
        private readonly AzureMLRequestOptions _azureMLRequestOptions;
        private readonly ILogger _logger;
        public ProxyController(AzureMLRequestOptions azureMLRequestOptions,ILogger logger)
        {
            _azureMLRequestOptions = azureMLRequestOptions;
            _logger = logger;
        }

        [HttpPost]
        public async Task<AzureMLRankResponse> Infer([FromBody] AzureMLRankRequest azureMLRankRequest)
        {
            _logger.Information("Request Object is {@request}",azureMLRankRequest);
            //c#中用来做请求的client
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_azureMLRequestOptions.Key}");
                var content = new StringContent(JsonConvert.SerializeObject(azureMLRankRequest), Encoding.UTF8, "application/json");
                //异步调用中await,得到返回值eg.(针对response)
                //var task = httpClient.PostAsync(_azureMLRequestOptions.Url, content);
                //var result = task.Result;或者
                //var response = httpClient.PostAsync(_azureMLRequestOptions.Url, content).GetAwaiter();
                var response = await httpClient.PostAsync(_azureMLRequestOptions.Url, content);
                //把content按照string读出.
                var json = await response.Content.ReadAsStringAsync();
                //jsonConvert反序列化json
                var result = JsonConvert.DeserializeObject<AzureMLRankResponse>(json);
                return result;
            }
        }
    }
}
