using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;
using API.Source.Repository;
using API.Source.Service;

namespace API.Source.Base.Ioc
{
    public static class Ioc
    {
        public static void LoadInjectorDependencie(IServiceCollection service)
        {
            //service
            service.AddScoped<IProfissionalService, ProfissionalService>();
            service.AddScoped<IPacienteService, PacienteService>();
            service.AddScoped<IAgendamentoService, AgendamentoService>();
            service.AddScoped<IDataAgendamentoService, HoraAgendamentoService>();

            //repository
            service.AddScoped<IProfissionalRepository, ProfissionalRepository>();
            service.AddScoped<IPacienteRepository, PacienteRepository>();
            service.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            service.AddScoped<IDataAgendamentoRepository, HoraAgendamentoRepository>();
        }
    }
}
