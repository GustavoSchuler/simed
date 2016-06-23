using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
            Papel = Papel.USUARIO;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Papel Papel { get; set; } 
    }

    public enum Papel
    {
        USUARIO = 0, MEDICO = 1, ADMIN = 2
    }
}
