using API.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Base.SQL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DataContext() { }


        //DbSet
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<HoraAgendamento> HoraAgendamento { get; set; }
    }
}
