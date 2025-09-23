using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticoBiblioteca.Shared.DTOs;

namespace PracticoBiblioteca.Services.Interfaces
{
    public interface ISesionService
    {
        SesionDTO? SesionActual { get; }
        Task GuardarSesionAsync(SesionDTO sesion);
        Task CerrarSesionAsync();
    }
}
