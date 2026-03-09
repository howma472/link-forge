using LinkForge.Application.DTO;
using LinkForge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkForge.Web.Controllers;

public class LinkController : Controller
{
    private readonly LinkService _service;

    public LinkController(LinkService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var links = await _service.GetAllAsync();
        return View(links);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkRequest request)
    {
        await _service.CreateAsync(request);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var links = await _service.GetAllAsync();
        var link = links.FirstOrDefault(x => x.Id == id);

        return View(link);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateLinkRequest request)
    {
        await _service.UpdateAsync(request);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }
    
}