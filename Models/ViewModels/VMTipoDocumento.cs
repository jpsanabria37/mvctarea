using System;
using System.Collections.Generic;

namespace mvctarea.Models
{
    public partial class VMTipoDocumento
    {
        //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio
        public VMTipoDocumento()
        {
            
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public bool Estado { get; set; }  = true;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    
    }
}
