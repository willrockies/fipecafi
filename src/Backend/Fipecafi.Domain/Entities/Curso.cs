namespace Fipecafi.Domain.Entities;

public class Curso : EntityBase
{
    public string Descricao { get; set; } = string.Empty;
    public ICollection<Lead> Leads { get; set; }
} 
