﻿using API.Model;
using API.Model.Data;

namespace API.Source.Base.Contracts.Repository
{
    public interface IAgendamentoRepository
    {
        Task<Agendamento> Create(Agendamento createDTO);
        Task<AgendamentoResponse> Get(int id);
        Task<List<AgendamentoResponse>> List();
        Task<Agendamento> Update(Agendamento updateDTO);
        Task<bool> Delete(int id);
        Task<AgendamentoResponse> GetByProfissional(int profissionalId);
    }
}
