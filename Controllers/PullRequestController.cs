using github_webhook_notify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace github_webhook_notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PullRequestController : ControllerBase
    {
        private readonly ILogger<PullRequestController> _logger;

        public PullRequestController(ILogger<PullRequestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void ReceiveWebhook(GithubPayload payload)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            _logger.Log(LogLevel.Information, "GitHub webhook received from {Ip}", ip);

            if (!(payload.Action == "closed" && payload.PullRequest.Merged))
            {
                _logger.Log(LogLevel.Debug, "Received a non-merged pull request");
                return;
            }

            _logger.Log(LogLevel.Debug, "Received a merged pull request");
        }
    }
}