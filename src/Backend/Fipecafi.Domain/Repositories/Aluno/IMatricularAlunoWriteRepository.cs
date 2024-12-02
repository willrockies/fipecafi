using Fipecafi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipecafi.Domain.Repositories.Aluno
{
    public interface IMatricularAlunoWriteRepository
    {
        Task<bool> Add(Entities.Aluno aluno);
        Task<int> GetNextCodigoMatricula();
        Task<IEnumerable<Turma>> GetTurmasByCursoId(int cursoId);
        //Task<bool> MatricularAluno(Entities.Aluno aluno);
    }
}
