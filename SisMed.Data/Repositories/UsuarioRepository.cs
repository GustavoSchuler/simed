using SisMed.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisMed.Domain.Entities;
using SisMed.Data.Context;

namespace SisMed.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Domain.Entities.Usuario>, IUsuarioRepository
    {
        private readonly SisMedContext mDb;

        public UsuarioRepository()
        {
            mDb = new SisMedContext();
        }

        public void Dispose()
        {
            mDb.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario ObterPorId(string id)
        {
            return mDb.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return mDb.Usuarios.ToList();
        }

        public Usuario ObterAutenticacao(Usuario usuario)
        {
            return mDb.Usuarios.Find(usuario);
        }
    }
}
