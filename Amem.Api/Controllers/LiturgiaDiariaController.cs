using Amem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amem.Api.Controllers;

[ApiController]
[Route("api/liturgia")]
public class LiturgiaDiariaController : ControllerBase
{
    private readonly ILiturgiaDiariaService _liturgiaDiariaService;
    
    public LiturgiaDiariaController(ILiturgiaDiariaService liturgiaDiariaService)
    {
        _liturgiaDiariaService = liturgiaDiariaService;
    }
    
    [HttpGet("hoje")]
    public async Task<IActionResult> GetLiturgiaHoje()
    {
        var hoje = DateOnly.FromDateTime(DateTime.Today);
        var liturgiaDiaria = await _liturgiaDiariaService.GetLiturgiaDiariaByDateAsync(hoje);
        
        if (liturgiaDiaria == null) return NotFound();
        return Ok(liturgiaDiaria);
    }

    [HttpGet("{data}")]
    public async Task<IActionResult> GetLiturgiaByDate(DateOnly data)
    {
        var liturgiaDiaria = await _liturgiaDiariaService.GetLiturgiaDiariaByDateAsync(data);
        
        if (liturgiaDiaria == null) return NotFound();
        return Ok(liturgiaDiaria);
    }
}