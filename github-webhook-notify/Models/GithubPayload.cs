namespace github_webhook_notify.Models
{
    public class GithubPayload
    {
        public string Action { get; set; }
        public int Number { get; set; }
        public PullRequest PullRequest { get; set; }
    }
}