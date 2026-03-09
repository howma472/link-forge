using LinkForge.Application.Queries;
using LinkForge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkForge.Web.Controllers;

/// <summary>
/// Контроллер редиректа коротких ссылок
/// </summary>
public class RedirectController : Controller
{
    private readonly GetLinkByCodeQuery _query;
    private readonly LinkService _service;

    public RedirectController(GetLinkByCodeQuery query, LinkService service)
    {
        _query = query;
        _service = service;
    }

    [HttpGet("/{code}")]
    public async Task<IActionResult> RedirectToOriginal(string code)
    {
        var link = await _query.ExecuteAsync(code);

        if (link == null)
            return NotFound();

        await _service.IncrementClickAsync(link.Id);

        return Redirect(link.OriginalUrl);
    }
}