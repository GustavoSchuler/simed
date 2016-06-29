using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Application.Interface
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario ObterAutenticacao(Usuario usuario);

        void AlterarRoleUsuario(int id, Papel role);
    }
}
