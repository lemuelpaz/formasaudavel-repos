using API.Model.Data;

namespace API.Source.Base.Contracts.Service
{
    public interface IPacienteService
    {
        Task<Paciente> Create(Paciente createDTO);
        Task<Paciente> Get(int id);
        Task<List<Paciente>> List();
        Task<Paciente> Update(Paciente updateDTO);
        Task<bool> Delete(int id);
    }
}
