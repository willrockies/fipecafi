using AutoMapper;
using Fipecafi.Application.Services.AutoMapper;
using Fipecafi.Application.Usecases.Cursos.Read;
using Fipecafi.Application.Usecases.Leads.Read;
using Fipecafi.Application.Usecases.Leads.Register;
using Fipecafi.Application.Usecases.Matricular.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Fipecafi.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCase(services);
        }
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterLeadUseCase, RegisterLeadUseCase>();
            services.AddScoped<IReadLeadsUseCase, ReadLeadsUseCase>();
            services.AddScoped<IReadCursosUseCase, ReadCursosUseCase>();
            services.AddScoped<IRegisterMatricularAlunoUseCase, RegisterMatricularAlunoUseCase>();

            
        }
    }
}
