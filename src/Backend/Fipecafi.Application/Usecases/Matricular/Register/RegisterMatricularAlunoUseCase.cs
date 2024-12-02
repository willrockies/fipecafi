using Fipecafi.Application.Usecases.Leads.Read;
using Fipecafi.Communication.Requests;
using Fipecafi.Domain.Entities;
using Fipecafi.Domain.Repositories.Aluno
;
using Fipecafi.Domain.Repositories.Lead;
namespace Fipecafi.Application.Usecases.Matricular.Register;

public class RegisterMatricularAlunoUseCase : IRegisterMatricularAlunoUseCase
{
    private readonly IMatricularAlunoWriteRepository _matricularAlunoWriteRepository;
    private readonly ILeadReadOnlyRepository _leadReadOnlyRepository;

    public RegisterMatricularAlunoUseCase(
        IMatricularAlunoWriteRepository matricularAlunoWriteRepository, ILeadReadOnlyRepository leadReadOnlyRepository)
    {
        _matricularAlunoWriteRepository = matricularAlunoWriteRepository;
        _leadReadOnlyRepository = leadReadOnlyRepository;
    }
    public async Task<bool> Execute(int leadId, int turmaId)
    {
        var lead = await _leadReadOnlyRepository.GetLeadByIdAsync(leadId);
        if (lead == null)
        {
            throw new KeyNotFoundException("Lead não encontrado.");
        }
        //if (string.IsNullOrWhiteSpace(request.Nome) ||
        //   string.IsNullOrWhiteSpace(request.Telefone) ||
        //   string.IsNullOrWhiteSpace(request.Email) ||
        //   request.CursoId <= 0 ||
        //   request.TurmaId <= 0)
        //    throw new ArgumentException("Todos os campos são obrigatórios.");



        //if (request.CursoId != lead.CursoId)
        //{
        //    throw new ArgumentException("O curso selecionado não corresponde ao curso associado ao lead.");
        //}
        var codigoMatricula = await _matricularAlunoWriteRepository.GetNextCodigoMatricula();

        var aluno = new Aluno
        {
            CodigoMatricula = codigoMatricula,
            Nome = lead.Nome,
            Telefone = lead.Telefone,
            Email = lead.Email,
            CursoId = lead.CursoId,
            TurmaId = turmaId,
            DataCadastro = DateTime.UtcNow
        };

        return await _matricularAlunoWriteRepository.Add(aluno);
    }
}
