using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.SQL;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public PacienteRepository(DataContext context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Cria novo Paciente
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<Paciente> Create(Paciente createDTO)
        {
            _context.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }


        /// <summary>
        /// Deleta Paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<bool> Delete(int id)
        {
            var getPaciente = await _context.Paciente.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (getPaciente == null)
                throw new Exception("Paciente não encontrado!");
            _context.Paciente.Remove(getPaciente);
            return await _context.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Get Paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Paciente> Get(int id)
        {
            var paciente = await _context.Paciente.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (paciente == null)
                throw new Exception("Paciente não encontrado");
            return paciente;
        }

        /// <summary>
        /// List Paciente
        /// </summary>
        /// <returns></returns>
        public async Task<List<Paciente>> List()
        {
            return await _context.Paciente.ToListAsync();
        }

        /// <summary>
        /// Update Paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Paciente> Update(Paciente updateDTO)
        {
            _context.Paciente.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }
    }
}
