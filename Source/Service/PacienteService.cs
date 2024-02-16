using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;

namespace API.Source.Service
{
    public class PacienteService : IPacienteService
    {

        #region Constructor
        private readonly IPacienteRepository _repository;
        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<Profissional> Create(Profissional createDTO)
        {
            return await _repository.Create(createDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Profissional> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Profissional>> List()
        {
            return await _repository.List();
        }

        public async Task<Profissional> Update(Profissional updateDTO)
        {
            return await _repository.Update(updateDTO);
        }
    }
}
