using DummyBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DummyFunc
{
    public class DummyCSFunc
    {
        [FunctionName("DummyCSFunc")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Dummy(ConStr = "MyConStrSetting")] out DummyMessage outDummy,
            [Dummy(ConStr = "MyConStrSetting")] DummyMessage inDummy,
            ILogger log)
        {
            // output binding
            outDummy = new DummyMessage
            {
                Id = "Sending out from",
                Name = "C# Func"
            };

            // print the input binding to screen
            return new OkObjectResult($"I got Id: {inDummy.Id} and Name: {inDummy.Name} from the binding");
        }
    }
}
