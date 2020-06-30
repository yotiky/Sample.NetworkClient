using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using MessagePack;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Sample.NetworkClient.Server
{
    public static class EchoSerializedForGet
    {
        [FunctionName("EchoSerializedForGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var headers = string.Join("&", req.Headers.Select(x => x.Key + "=" + x.Value));
            var queryString = string.Join("&", req.Query.Select(x => x.Key + "=" + x.Value));
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var result = new Rootobject
            {
                Headers = headers,
                QueryString = queryString,
                Body = requestBody,
            };

            var serialized = MessagePackSerializer.Serialize(result);

            return new FileContentResult(serialized, "application/octet-stream");
        }
    }

    [MessagePackObject]
    public class Rootobject
    {
        [Key(0)]
        public string Headers { get; set; }
        [Key(1)]
        public string QueryString { get; set; }
        [Key(2)]
        public string Body { get; set; }
    }

}
