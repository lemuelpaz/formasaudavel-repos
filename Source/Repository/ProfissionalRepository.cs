using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.SQL;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Repository
{
    public class ProfissionalRepository : IMedicoRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public ProfissionalRepository(DataContext context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Cria novo medico
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<Medico> Create(Medico createDTO)
        {
            _context.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }


        /// <summary>
        /// Deleta Medicos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<bool> Delete(int id)
        {
            var getUser = await _context.Medico.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (getUser == null)
                throw new Exception("Medico não encontrado!");
            _context.Medico.Remove(getUser);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Get medico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Medico> Get(int id)
        {
            var medico = await _context.Medico.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (medico == null)
                throw new Exception("Medico não encontrado");
            return medico;
        }

        /// <summary>
        /// List Medicos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Medico>> List()
        {
            return await _context.Medico.ToListAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Medico> Update(Medico updateDTO)
        {
            _context.Medico.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }
    }
}
