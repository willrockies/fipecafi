using Fipecafi.Application.Usecases.Cursos.Read;
using Fipecafi.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fipecafi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursoController : FipecafiBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseCursoJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IReadCursosUseCase useCase)
        {
            var cursos = await useCase.Execute();
            return Ok(cursos);
        }

        [HttpGet("{cursoId:int}")]
        public async Task<IActionResult> GetCursoDescricaoById([FromServices] IReadCursosUseCase useCase, int cursoId)
        {
            try
            {
                var descricao = await useCase.GetCursoDescricaoByIdAsync(cursoId);
                return Ok(new { Descricao = descricao });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Error = ex.Message });
            }
        }
    }
}
