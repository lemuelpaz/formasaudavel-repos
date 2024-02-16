using API.Model.Data;

namespace API.Source.Base.Contracts.Repository
{
    public interface IMedicoRepository
    {
        Task<Profissional> Create(Profissional createDTO);
        Task<Profissional> Get(int id);
        Task<List<Profissional>> List();
        Task<Profissional> Update(Profissional updateDTO);
        Task<bool> Delete(int id);
    }
}
