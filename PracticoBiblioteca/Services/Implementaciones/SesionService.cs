using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticoBiblioteca.Shared.DTOs;

namespace PracticoBiblioteca.Services.Implementaciones
{
    public class SesionService
    {
        private SesionDTO? _sesion;

        public SesionDTO? SesionActual => _sesion;

        public async Task GuardarSesionAsync(SesionDTO sesion)
        {
            _sesion = sesion;
            await Task.CompletedTask; // para mantener estilo async
        }

        public async Task CerrarSesionAsync()
        {
            _sesion = null;
            await Task.CompletedTask;
        }
    }
}
