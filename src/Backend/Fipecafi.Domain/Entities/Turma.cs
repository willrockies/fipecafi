using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipecafi.Domain.Entities
{
    public class Turma : EntityBase
    {
        public string Descricao { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
