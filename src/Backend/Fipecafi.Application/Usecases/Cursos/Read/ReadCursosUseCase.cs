using AutoMapper;
using Fipecafi.Communication.Responses;
using Fipecafi.Domain.Repositories.Curso;

namespace Fipecafi.Application.Usecases.Cursos.Read
{
    public class ReadCursosUseCase : IReadCursosUseCase
    {
        private readonly ICursoReadOnlyRepository _cursoReadOnlyRepository;
        public ReadCursosUseCase(ICursoReadOnlyRepository cursoReadOnlyRepository)
        {
            _cursoReadOnlyRepository = cursoReadOnlyRepository;
        }

        public async Task<IEnumerable<ResponseCursoJson>> Execute()
        {
            var cursos = await _cursoReadOnlyRepository.GetCursos();

            var response = cursos.Select(curso => new ResponseCursoJson
            {
                Id = curso.Id,
                Descricao = curso.Descricao
            });

            return response;
        }

        public async Task<string> GetCursoDescricaoByIdAsync(int cursoId)
        {
            var curso = await _cursoReadOnlyRepository.GetCursoById(cursoId);

            if (curso == null)
                throw new KeyNotFoundException("Curso não encontrado.");

            return curso.Descricao;
        }
    }
}
