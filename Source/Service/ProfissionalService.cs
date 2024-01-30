using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;

namespace API.Source.Service
{
    public class ProfissionalService : IMedicoService
    {

        #region Constructor
        private readonly IMedicoRepository _repository;
        public ProfissionalService(IMedicoRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<Medico> Create(Medico createDTO)
        {
            return await _repository.Create(createDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Medico> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Medico>> List()
        {
            return await _repository.List();
        }

        public async Task<Medico> Update(Medico updateDTO)
        {
            return await _repository.Update(updateDTO);
        }
    }
}
