using Fipecafi.Application.Usecases.Matricular.Register;
using Fipecafi.Communication.Requests;
using Fipecafi.Domain.Repositories.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace Fipecafi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunosController : FipecafiBaseController
    {
        [HttpPost("matricular/{leadId:int}")]
        public async Task<IActionResult> Matricular(
            int leadId,
        [FromBody] RequestRegisterMatricularJson request,
        [FromServices] IRegisterMatricularAlunoUseCase useCase)
        {
            try
            {
                var resultado = await useCase.Execute(leadId, request.TurmaId);
                if (resultado)
                {
                    return Ok(new { Message = "Aluno matriculado com sucesso!" });
                }

                return StatusCode(500, new { Message = "Erro ao matricular aluno." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Error = ex.Message });
            }
        }

        [HttpGet("turmas/{cursoId:int}")]
        public async Task<IActionResult> GetTurmasPorCurso(
        int cursoId,
        [FromServices] IMatricularAlunoWriteRepository alunoRepository)
        {
            try
            {
                var turmas = await alunoRepository.GetTurmasByCursoId(cursoId);
                return Ok(turmas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Error = ex.Message });
            }
        }
    }
}
