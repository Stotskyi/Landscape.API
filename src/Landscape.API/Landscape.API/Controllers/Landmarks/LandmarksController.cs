using Landscape.Application.Landmark.GetLandmark;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Landscape.API.Controllers.Landmarks;

[ApiController]
[Route("/api/landmarks")]
public class LandmarksController : ControllerBase
{
    private readonly ISender _sender;

    public LandmarksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> SearchLandmarks(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetLandmarkQuery(id);
        
        var result = await _sender.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("test")]
    public async Task<IActionResult> Get()
    {
        return Ok(" i am fucking working now!");
    }
}