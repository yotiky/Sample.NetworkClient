using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Sample.NetworkClient.Server
{
    public static class EchoForPost
    {
        [FunctionName("EchoForPost")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var headers = string.Join("&", req.Headers.Select(x => x.Key + "=" + x.Value));
            var queryString = string.Join("&", req.Query.Select(x => x.Key + "=" + x.Value));
            var requestBody = "";

            using (var ms = new MemoryStream())
            {
                await req.Body.CopyToAsync(ms);
                ms.Position = 0;
                requestBody = BitConverter.ToString(ms.ToArray());
            }

            var jo = new JObject();
            jo["Headers"] = headers;
            jo["QueryString"] = queryString;
            jo["Body"] = requestBody;

            return new OkObjectResult(jo.ToString());
        }
    }
}
