using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
