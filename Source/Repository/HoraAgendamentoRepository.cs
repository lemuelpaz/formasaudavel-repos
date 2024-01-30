using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.SQL;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Repository
{
    public class HoraAgendamentoRepository : IDataAgendamentoRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public HoraAgendamentoRepository(DataContext context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Cria 
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<HoraAgendamento> Create(HoraAgendamento createDTO)
        {
            try
            {
                _context.ChangeTracker.Clear();
                await _context.HoraAgendamento.AddAsync(createDTO);
                await _context.SaveChangesAsync();
                return createDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Deleta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<bool> Delete(int id)
        {
            var hora = await _context.HoraAgendamento.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (hora == null)
                throw new Exception("Horario não encontrado!");
            _context.HoraAgendamento.Remove(hora);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<HoraAgendamento> Get(int id)
        {
            var hora = await _context.HoraAgendamento.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (hora == null)
                throw new Exception("Horario não encontrado");
            return hora;
        }

        /// <summary>
        /// List 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HoraAgendamento>> List()
        {
            return await _context.HoraAgendamento.ToListAsync();
        }

        /// <summary>
        /// List 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HoraAgendamento>> ListByProfissional(int? profissionalId)
        {
            var query = from a in _context.HoraAgendamento
                        where a.ProfissionalId == profissionalId && a.Ativo == true
                        select a;
            return await query.ToListAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<HoraAgendamento> Update(HoraAgendamento updateDTO)
        {
            _context.HoraAgendamento.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }
    }
}
