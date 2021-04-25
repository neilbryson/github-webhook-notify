namespace github_webhook_notify.Models
{
    public class PullRequest
    {
        public int Id { get; set; }
        public bool Merged { get; set; }
        public string MergedAt { get; set; }
        public string State { get; set; }
        public string Url { get; set; }
    }
}