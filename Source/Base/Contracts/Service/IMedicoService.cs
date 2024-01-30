using API.Model.Data;

namespace API.Source.Base.Contracts.Service
{
    public interface IMedicoService
    {
        Task<Medico> Create(Medico createDTO);
        Task<Medico> Get(int id);
        Task<List<Medico>> List();
        Task<Medico> Update(Medico updateDTO);
        Task<bool> Delete(int id);
    }
}
