using Fipecafi.Domain.Repositories.Lead;
using Fipecafi.Infrastructure.DataAccess;
using Fipecafi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Fipecafi.Domain.Repositories;
using Fipecafi.Domain.Repositories.Curso;
using Fipecafi.Domain.Repositories.Aluno;

namespace Fipecafi.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrasctruture(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        //var connectionString = configuration.ConnectionString();
        var connectionString = "Data Source=DESKTOP-A0C6ICI\\FIPECAFI;Initial Catalog=fipecafi;User ID=sa;Password=@cesso123;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        services.AddDbContext<FipecafiDBContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(connectionString);
        });

    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitofWork, UnitOfWork>();
        services.AddScoped<ILeadWriteOnlyRepository, LeadRepository>();
        services.AddScoped<ILeadReadOnlyRepository, LeadRepository>();
        services.AddScoped<ICursoReadOnlyRepository, CursoRepository>();
        services.AddScoped<IMatricularAlunoWriteRepository, AlunoRepository>();
    }
}
