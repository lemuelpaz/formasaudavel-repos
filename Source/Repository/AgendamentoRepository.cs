using API.Model;
using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.SQL;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public AgendamentoRepository(DataContext context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Cria novo
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<Agendamento> Create(Agendamento createDTO)
        {
            _context.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }


        /// <summary>
        /// Deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<bool> Delete(int id)
        {
            var getAgendamento = await _context.Agendamento.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (getAgendamento == null)
                throw new Exception("Agendamento não encontrado!");
            _context.Agendamento.Remove(getAgendamento);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AgendamentoResponse> Get(int id)
        {
            var agendamento = await (from a in _context.Agendamento
                                     join b in _context.Paciente on a.PacienteId equals b.Id
                                     join c in _context.Medico on a.ProfissionalId equals c.Id
                                     where a.Id == id
                                     select new AgendamentoResponse
                                     {
                                         Id = a.Id,
                                         ProfissionalId = a.ProfissionalId,
                                         Atendimento = a.Atendimento,
                                         Horario = a.Horario,
                                         Observacao = a.Observacao,
                                         PacienteId = a.PacienteId,
                                         PacienteNome = b.Nome,
                                         ProfissionalNome = c.Nome
                                     }).FirstOrDefaultAsync();

            if (agendamento == null)
                throw new Exception("Agendamento não encontrado");
            return agendamento;
        }

        public async Task<AgendamentoResponse> GetByProfissional(int profissionalId)
        {
            var agendamento = await (from a in _context.Agendamento
                                     join b in _context.Paciente on a.PacienteId equals b.Id
                                     join c in _context.Medico on a.ProfissionalId equals c.Id
                                     where a.ProfissionalId == profissionalId
                                     select new AgendamentoResponse
                                     {
                                         Id = a.Id,
                                         ProfissionalId = a.ProfissionalId,
                                         Atendimento = a.Atendimento,
                                         Horario = a.Horario,
                                         Observacao = a.Observacao,
                                         PacienteId = a.PacienteId,
                                         PacienteNome = b.Nome,
                                         ProfissionalNome = c.Nome
                                     }).FirstOrDefaultAsync();

            if (agendamento == null)
                throw new Exception("Agendamento do profissional não encontrado");
            return agendamento;
        }

        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        public async Task<List<AgendamentoResponse>> List()
        {
            var agendamentoList = await (from a in _context.Agendamento
                                         join b in _context.Paciente on a.PacienteId equals b.Id
                                         join c in _context.Medico on a.ProfissionalId equals c.Id
                                         select new AgendamentoResponse
                                         {
                                             Id = a.Id,
                                             ProfissionalId = a.ProfissionalId,
                                             Atendimento = a.Atendimento,
                                             Horario = a.Horario,
                                             Observacao = a.Observacao,
                                             PacienteId = a.PacienteId,
                                             PacienteNome = b.Nome,
                                             ProfissionalNome = c.Nome
                                         }).ToListAsync();
            return agendamentoList;
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Agendamento> Update(Agendamento updateDTO)
        {
            _context.Agendamento.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }
    }
}
