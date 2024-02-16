using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.SQL;
using API.Source.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Source.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Profissional> Auth(AuthRequest request)
        {
            IQueryable<Profissional> query = _context.Profissional;
            query = query.Where(x => x.Email == request.Email);
            if (query == null)
                throw new Exception("Email ou senha invalidos!");
            return await query.FirstOrDefaultAsync();
        }
    }
}
