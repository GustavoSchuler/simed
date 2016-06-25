using SisMed.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    public class Usuario
    {
        private string password;

        public Usuario()
        {
            Papel = Papel.USUARIO;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = CriptoService.Sha1(value);
            }
        }

        public Papel Papel { get; set; } 
    }

    public enum Papel
    {
        USUARIO = 0, MEDICO = 1, ADMIN = 2
    }
}
