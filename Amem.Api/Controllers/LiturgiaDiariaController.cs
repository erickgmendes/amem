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

        try
        {
            var liturgiaDiaria = await _liturgiaDiariaService.GetLiturgiaDiariaByDateAsync(hoje);
            return Ok(liturgiaDiaria);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
        
    }

    [HttpGet("{data}")]
    public async Task<IActionResult> GetLiturgiaByDate(DateOnly data)
    {
        try
        {
            var liturgiaDiaria = await _liturgiaDiariaService.GetLiturgiaDiariaByDateAsync(data);
            return Ok(liturgiaDiaria);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }
}