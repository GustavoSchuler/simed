using SisMed.Domain.Entities;

namespace SisMed.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ObterAutenticacao(Usuario usuario);

        void AlterarRoleUsuario(int id, Papel role);
    }
}
