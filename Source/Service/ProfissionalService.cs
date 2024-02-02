using API.Model;
using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;

namespace API.Source.Service
{
    public class ProfissionalService : IProfissionalService
    {

        #region Constructor
        private readonly IProfissionalRepository _repository;
        public ProfissionalService(IProfissionalRepository repository)
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

        public List<CargoResponse> CargoType()
        {
            List<CargoResponse> cargoResponses = new List<CargoResponse>();

            foreach (CargoType item in Enum.GetValues(typeof(CargoType)))
            {
                CargoResponse cargoResponse = new CargoResponse();
                cargoResponse.Id = (int)item;
                cargoResponse.CargoName = item.ToString();
                cargoResponses.Add(cargoResponse);
            }

            return cargoResponses;
        }
    }
}
