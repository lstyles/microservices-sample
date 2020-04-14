using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Frontend.Config;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Frontend.Controllers
{
    [Route("")]
    [ApiController]
    public class FrontendController : ControllerBase
    {
        private readonly FrontendOptions _options;
        private static HttpClient _httpClient = new HttpClient();

        public FrontendController(IOptions<FrontendOptions> options)
        {
            _options = options.Value;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = new FrontendResponseModel
            {
                ResponseText = _options.ResponseText
            };

            foreach (var backend in _options.BackendServices)
            {
                try
                {
                    var response = await _httpClient.GetAsync(backend);
                    if (response.IsSuccessStatusCode)
                    {
                        result.BackendResponses.Add(backend, await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        result.BackendResponses.Add(backend, response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    result.BackendResponses.Add(backend, $"Error: {ex.Message}");
                }
            }

            return Ok(result);
        }
    }
}