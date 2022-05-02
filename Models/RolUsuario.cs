using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class RolUsuario
    {
        public uint Id { get; set; }
        public uint UsuarioId { get; set; }
        public uint RolId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
