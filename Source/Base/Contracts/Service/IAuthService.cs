using API.Model.Data;
using API.Source.Models;

namespace API.Source.Base.Contracts.Service
{
    public interface IAuthService
    {
        Task<AuthResponse> Auth(AuthRequest request);
    }
}
