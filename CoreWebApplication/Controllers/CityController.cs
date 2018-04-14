using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWeb.Controllers
{
    [Produces("application/json")]
    //[Route("api/City")]
    [Route("api/[controller]")] //[] token Replacement [controller], [area], [action]
    public class CityController : Controller
    {
        public CityController(IConfigurationRoot config,  ILogger<CityController> logger)
        {

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "City 1", "City 2" };
        }
    }
}