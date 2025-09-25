using PracticoBiblioteca.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<CloudinaryResponseDTO?> SubirImagen(Stream fileStream, string fileName);

    }
}
