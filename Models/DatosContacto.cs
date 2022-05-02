using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class DatosContacto
    {
        public uint Id { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailEmpresa { get; set; }
        public string DireccionCasa { get; set; }
        public string DireccionTrabajo { get; set; }
        public uint? PropietarioId { get; set; }
        public uint? UsuarioId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Propietario Propietario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
