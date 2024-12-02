using Fipecafi.Application.Usecases.Leads.Read;
using Fipecafi.Application.Usecases.Leads.Register;
using Fipecafi.Communication.Requests;
using Fipecafi.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fipecafi.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LeadController : FipecafiBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredLeadsJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterLeadUseCase useCase,
        [FromBody] RequestRegisterLeadsJson request)
    {

        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ResponseReadLeadJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLead(
        [FromServices] IReadLeadsUseCase useCase,
        [FromQuery] string? nome,
        [FromQuery] string? email,
        [FromQuery] int? cursoId)
    {
        var leads = await useCase.Execute(nome, email, cursoId);
        return Ok(leads);
    }
}
