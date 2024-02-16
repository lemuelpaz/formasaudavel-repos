using API.Model.Data;

namespace API.Source.Base.Contracts.Service
{
    public interface IPacienteService
    {
        Task<Profissional> Create(Profissional createDTO);
        Task<Profissional> Get(int id);
        Task<List<Profissional>> List();
        Task<Profissional> Update(Profissional updateDTO);
        Task<bool> Delete(int id);
    }
}
