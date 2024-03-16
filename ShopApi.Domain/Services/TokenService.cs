using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Domain.Commands.LoginCommand;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Enums;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Services
{
    public class TokenService
    {
         private readonly IClienteRepository _clienteRepository; // Supondo que você tenha um repositório para clientes

        public TokenService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public string GenerateToken(Usuario usuario)
        {
            var tokenHanlder = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sdasdawdqwfjiadasdasdqwdqsxqwd232543123cnouasdbqw");
            var claims = new List<Claim>
            {
                usuario.Login != null ? new Claim(ClaimTypes.Name, usuario.Login) : new Claim(ClaimTypes.Name, ""),
                usuario.Cliente.Nome != null ? new Claim("ClienteNome", usuario.Cliente.Nome) : new Claim("ClienteNome", ""),
                usuario.Cliente.ETipoAcesso != null ? new Claim("TipoAcesso", usuario.Cliente.ETipoAcesso.ToString()) : new Claim("TipoAcesso", ""),
            };
            
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHanlder.CreateToken(TokenDescriptor);
            return tokenHanlder.WriteToken(token);
        }
    }
}