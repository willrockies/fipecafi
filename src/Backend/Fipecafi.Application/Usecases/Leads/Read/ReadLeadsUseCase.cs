using Fipecafi.Communication.Responses;
using Fipecafi.Domain.Repositories.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipecafi.Application.Usecases.Leads.Read
{
    public class ReadLeadsUseCase : IReadLeadsUseCase
    {
        private readonly ILeadReadOnlyRepository _leadReadOnlyRepository;

        public ReadLeadsUseCase(ILeadReadOnlyRepository leadReadOnlyRepository)
        {
            _leadReadOnlyRepository = leadReadOnlyRepository;
        }

        public async Task<IEnumerable<ResponseReadLeadJson>> Execute(string? nome, string? email, int? cursoId)
        {
            var leads = await _leadReadOnlyRepository.GetLeads(nome, email, cursoId);

            return leads.Select(lead => new ResponseReadLeadJson
            {
                Id = lead.Id,
                Nome = lead.Nome,
                Email = lead.Email,
                Telefone = lead.Telefone,
                CursoInteresse = lead.Curso.Descricao,
                CursoId = lead.CursoId
            });
        }
    }
}
