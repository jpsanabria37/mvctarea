using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class TipoDocumento
    {
        //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio
        public TipoDocumento()
        {
            Propietarios = new HashSet<Propietario>();
            Usuarios = new HashSet<Usuario>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime? CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Propietario> Propietarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
