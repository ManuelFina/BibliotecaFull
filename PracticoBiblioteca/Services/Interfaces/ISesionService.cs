using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Services.Interfaces
{
    public interface ISesionService
    {
        Task<SesionDTO?> AutenticacionAsync(LoginDTO login);
        Task<Usuario> RegistrarAsync(RegistroDTO dto);
        Task<SesionDTO?> ObtenerSesionAsync();
        void GuardarSesion(SesionDTO sesion);  // Guarda la sesión en memoria
        void CerrarSesion();
    }
}
