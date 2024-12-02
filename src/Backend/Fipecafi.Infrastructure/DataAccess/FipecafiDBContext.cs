using Fipecafi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fipecafi.Infrastructure.DataAccess;

public class FipecafiDBContext : DbContext
{
    public FipecafiDBContext(DbContextOptions options) : base(options) { }

    public DbSet<Lead> Leads { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Turma> Turmas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FipecafiDBContext).Assembly);
    }

}
