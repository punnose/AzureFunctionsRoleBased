using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Linq;
 

namespace RoleBasedAzureAppRoles
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ClaimsPrincipal principal)
        {

           
            var roles = principal.Claims.Where(e => e.Type == "roles").Select(e => e.Value);
            //var pName = principal.Identity.Name;
           // var c = principal.Claims.Select(x => x.Value);

            //First get user claims    
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

            //Filter specific claim    
           //string username =  claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;

            return new OkObjectResult(roles);
        }
    }
}
