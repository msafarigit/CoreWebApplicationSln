using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAccess;
using CoreBusiness;
using CoreBusiness.BusinessLogic;
using CoreCommon.BaseInfo;
using CoreWeb.Models.BaseInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWeb.Controllers.BaseInfo
{
    [Produces("application/json")]
    [Route("api/[controller]")] //[] token Replacement [controller], [area], [action]
    public class CityController : BaseController<City, CityVM>
    {
        public CityController(IConfigurationRoot config,  ILogger<CityController> logger, CoreContext context)
        {
        }

        protected override IBusinessLogicRule<City> DefineBusinessLogicRule()
        {
            throw new NotImplementedException();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "City 1", "City 2" };
        }

    }
}