using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEmpleados.Modelos.Modelos
{
    public class Empleado
    {
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? CorreoElectronico { get; set; }

        public int Sueldo { get; set; }
        public DateTime FechaInicio { get; set; }
        public Cargo Cargo { get; set; }
        public string NombreCompleto => $"{PrimerNombre} {PrimerApellido}";
    }
}
