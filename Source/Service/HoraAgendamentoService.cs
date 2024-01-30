using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;

namespace API.Source.Service
{
    public class HoraAgendamentoService : IDataAgendamentoService
    {

        #region Constructor
        private readonly IDataAgendamentoRepository _repository;
        public HoraAgendamentoService(IDataAgendamentoRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<List<HoraAgendamento>> Create(HoraAgendamento createDTO)
        {
            List<HoraAgendamento> dataAgendamento = new List<HoraAgendamento>();
            TimeSpan horarioAtual = new TimeSpan(8, 0, 0);
            for (int i = 0; i < 21; i++)
            {
                createDTO.Hora = horarioAtual;
                createDTO.Id = 0;
                var result = await _repository.Create(createDTO);
                result.Hora = horarioAtual;
                dataAgendamento.Add(result);
                horarioAtual = horarioAtual.Add(new TimeSpan(0, 30, 0));
            }
            return dataAgendamento;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<HoraAgendamento> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<HoraAgendamento>> List()
        {
            return await _repository.List();
        }

        public async Task<List<HoraAgendamento>> ListByProfissional(int? profissionalId)
        {
            return await _repository.ListByProfissional(profissionalId);
        }

        public async Task<HoraAgendamento> Update(HoraAgendamento updateDTO)
        {
            return await _repository.Update(updateDTO);
        }
    }
}
