using API.Model.Data;
using API.Source.Models;

namespace API.Source.Base.Contracts.Repository
{
    public interface IAuthRepository
    {
        Task<Profissional> Auth(AuthRequest request);
    }
}
