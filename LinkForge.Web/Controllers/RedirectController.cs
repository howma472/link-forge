using LinkForge.Application.DTO;
using LinkForge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkForge.Web.Controllers;
/// <summary>
/// Контроллер редиректа.
/// 
/// Вынесен отдельно от CRUD-контроллера,
/// чтобы разделить ответственность:
/// 
/// LinkController → управление ссылками
/// RedirectController → переход по short url
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

        link.ClickCount++;

        await _service.UpdateAsync(new UpdateLinkRequest
        {
            Id = link.Id,
            OriginalUrl = link.OriginalUrl
        });

        return Redirect(link.OriginalUrl);
    }
}