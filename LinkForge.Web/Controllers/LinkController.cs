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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkRequestDto requestDto)
    {
        if (!ModelState.IsValid)
            return View(requestDto);

        await _service.CreateAsync(requestDto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var link = await _service.GetByIdAsync(id);

        if (link == null)
            return NotFound();

        return View(link);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateLinkRequestDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _service.UpdateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}