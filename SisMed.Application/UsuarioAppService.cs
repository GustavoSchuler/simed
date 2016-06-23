using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService mUsuarioService;

        public UsuarioAppService(IUsuarioService usuario) : base(usuario)
        {
            mUsuarioService = usuario;
        }

        public Usuario ObterAutenticacao(Usuario usuario)
        {
            return mUsuarioService.ObterAutenticacao(usuario);
        }
    }
}
