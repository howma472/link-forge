namespace LinkForge.Web.Models;

public class LinkViewModel
{
    public Guid Id { get; set; }
    public string OriginalUrl { get; set; } = "";
    public string ShortCode { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public int ClickCount { get; set; }
}