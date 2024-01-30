using API.Model;
using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;

namespace API.Source.Service
{
    public class AgendamentoService : IAgendamentoService
    {

        #region Constructor
        private readonly IAgendamentoRepository _repository;
        private readonly IDataAgendamentoService _dataAgendamento;
        public AgendamentoService(IAgendamentoRepository repository, IDataAgendamentoService dataAgendamento)
        {
            _repository = repository;
            _dataAgendamento = dataAgendamento;
        }
        #endregion

        public async Task<Agendamento> Create(Agendamento createDTO)
        {
            string data = createDTO.Horario!.Value.Date.ToString("dd/MM/yyyy");
            string horas = createDTO.Horario.Value.TimeOfDay.ToString("hh\\:mm");

            //GET DataProfissional
            List<HoraAgendamento> findDataAgendamento = await _dataAgendamento.ListByProfissional(createDTO.ProfissionalId);
            HoraAgendamento? dataAgendamento = null;
            if (findDataAgendamento.Count() > 0)
            {
                foreach (var item in findDataAgendamento)
                {
                    var dataAgenda = item.DataAgendamento!.Value.Date.ToString("dd/MM/yyyy");
                    var horaAgenda = item.Hora.ToString("hh\\:mm");


                    if (data == dataAgenda && horas == horaAgenda)
                    {
                        if (item.Ativo!.Value)
                        {
                            item.Ativo = false;
                            dataAgendamento = await _dataAgendamento.Update(item);
                            break;
                        }
                        else
                        {
                            throw new Exception("Horario ja foi agendado!");
                        }
                    }
                }

                if (dataAgendamento == null)
                {
                    throw new Exception("Data ou hora nao encotrado, ou não registrado para o profissional");
                }
            }
            else
            {
                throw new Exception("Data Agendamento não encontrado!");
            }

            return await _repository.Create(createDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<AgendamentoResponse> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<AgendamentoResponse> GetByProfissional(int profissionalId)
        {
            return await _repository.GetByProfissional(profissionalId);
        }

        public async Task<List<AgendamentoResponse>> List()
        {
            return await _repository.List();
        }

        public async Task<Agendamento> Update(Agendamento updateDTO)
        {
            return await _repository.Update(updateDTO);
        }
    }
}
