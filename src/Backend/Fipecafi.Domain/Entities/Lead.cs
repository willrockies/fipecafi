namespace Fipecafi.Domain.Entities;

public class Lead : EntityBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CursoId { get; set; }
    public Curso? Curso { get; set; }
}
