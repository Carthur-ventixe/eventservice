using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackagesController(IPackageRepository packageRepository) : ControllerBase
{
    private readonly IPackageRepository _packageRepository = packageRepository;

    [HttpPost]
    public async Task<IActionResult> Create(CreatePackageModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var entity = new PackageEntity
        {
            Title = model.Title,
            Position = model.Position,
            Placement = model.Placement,
        };

        var result = await _packageRepository.AddAsync(entity);
        if (result == null)
            return StatusCode(500, "Error creating package");

        return Ok(result);
    }

}
