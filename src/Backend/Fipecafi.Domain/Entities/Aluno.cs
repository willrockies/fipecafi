using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipecafi.Domain.Entities
{
    public class Aluno : EntityBase
    {
        public int CodigoMatricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CursoId { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataCadastro { get; set; }
        //public Lead Lead { get; set; }
        public Curso Curso { get; set; } 
        public Turma Turma { get; set; } 
    }
}
