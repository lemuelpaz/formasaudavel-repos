using API.Model.Data;
using API.Source.Base.Contracts.Repository;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Middlewares;
using API.Source.Models;

namespace API.Source.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthResponse> Auth(AuthRequest request)
        {
            Profissional profissional = await _repository.Auth(request);
            if (profissional == null)
                throw new Exception("Email ou senha invalidos!");
            var verifyPassword = profissional.SenhaValida(request.Password!);
            if (!verifyPassword)
                throw new Exception("Email ou senha invalidos!");

            return TokenService.GenerateToken(profissional);
        }
    }
}
