using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab.Models;
using Serilog;

// For more information on enabling Web API for empty projects,  visit https://go.microsoft.com/fwlink/?LinkID=397860
//

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            Log.Information("Acquiring version info");
            Log.Warning("Some warning");
            Log.Error("Here comes an error");
            var versionInfo = new VersionModel
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };
            Log.Information($"Current app version is: {versionInfo.ProductVersion}");
            Log.Information($"Current company is: {versionInfo.Company}");
            Log.Debug($"Full information: {@versionInfo}");
            return Ok(versionInfo);
        }
    }
}
