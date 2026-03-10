using LinkForge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkForge.Web.Controllers;
/// <summary>
/// Контроллер, выполняющий редирект по короткому коду ссылки.
/// </summary>
public class RedirectController : Controller
{
    private readonly LinkService _service;

    public RedirectController(LinkService service)
    {
        _service = service;
    }
    

    [HttpGet("/{code}")]
    public async Task<IActionResult> RedirectToOriginal(string code)
    {
        var link = await _service.GetByCodeAsync(code);

        if (link == null)
            return NotFound();

        await _service.IncrementClickAsync(link.Id);

        return Redirect(link.OriginalUrl);
    }
}