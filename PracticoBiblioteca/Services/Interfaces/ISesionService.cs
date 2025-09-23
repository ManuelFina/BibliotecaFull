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
        Task<SesionDTO?> IniciarSesionAsync(LoginDTO login);
        Task<SesionDTO?> ObtenerSesionAsync();
        void GuardarSesion(SesionDTO sesion);  // Guarda la sesión en memoria
        void CerrarSesion();
    }
}
