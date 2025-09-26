using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PracticoBiblioteca.Shared.Models
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Required]
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

        [Required]
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaDevolucion { get; set; }

        public bool Devuelto { get; set; } = false;
    }
}
