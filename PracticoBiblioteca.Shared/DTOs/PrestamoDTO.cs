using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Shared.DTOs
{
    public class PrestamoDTO
    {
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
