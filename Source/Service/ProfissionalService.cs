using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Utils;

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

        public async Task<Profissional> Create(Profissional createDTO)
        {
            createDTO.Password = CryptPassword.GerarHash(createDTO.Password!);
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
