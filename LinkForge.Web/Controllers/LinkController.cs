using LinkForge.Application.DTO;
using LinkForge.Application.Queries;
using LinkForge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkForge.Web.Controllers;

public class LinkController : Controller
{
    private readonly GetAllLinksQuery _getAllQuery;
    private readonly GetLinkByIdQuery _getByIdQuery;
    private readonly LinkService _service;

    public LinkController(
        GetAllLinksQuery getAllQuery,
        GetLinkByIdQuery getByIdQuery,
        LinkService service)
    {
        _getAllQuery = getAllQuery;
        _getByIdQuery = getByIdQuery;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var links = await _getAllQuery.ExecuteAsync();
        return View(links);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _service.CreateAsync(request);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var link = await _getByIdQuery.ExecuteAsync(id);

        if (link == null)
            return NotFound();

        return View(link);
    }
}