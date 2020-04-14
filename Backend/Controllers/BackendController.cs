using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Backend.Controllers
{
    [Route("")]
    [ApiController]
    public class BackendController : ControllerBase
    {
        private readonly BackendOptions _options;

        public BackendController(IOptions<BackendOptions> options)
        {
            _options = options.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_options.ResponseText);
        }
    }
}