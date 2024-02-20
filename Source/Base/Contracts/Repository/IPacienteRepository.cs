using API.Model.Data;

namespace API.Source.Base.Contracts.Repository
{
    public interface IPacienteRepository
    {
        Task<Paciente> Create(Paciente createDTO);
        Task<Paciente> Get(int id);
        Task<List<Paciente>> List();
        Task<Paciente> Update(Paciente updateDTO);
        Task<bool> Delete(int id);
    }
}
