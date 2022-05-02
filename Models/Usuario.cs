using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public uint Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public uint? TipoDocumentoId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual DatosContacto DatosContacto { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
