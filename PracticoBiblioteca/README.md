# PracticoBiblioteca
# 📚 Biblioteca App - .NET MAUI Blazor Hybrid

Aplicación móvil desarrollada con **.NET MAUI Blazor Hybrid**, que implementa un sistema maestro-detalle para usuarios y libros, con imágenes locales, login y un menú principal con íconos de **Bootstrap 5**.

---

## 🚀 Características

1. **Maestro-Detalle de Usuarios (ABM)**
   - Alta, baja y modificación de usuarios.
   - Imágenes de perfil almacenadas localmente.

2. **Maestro-Detalle de Libros (Entidad de negocio)**
   - Gestión de libros en la biblioteca.
   - Soporte para imágenes locales de portadas.

3. **Modelos**
   - Modelos C# para representar entidades de negocio (`Usuario`, `Libro`).

4. **Servicios**
   - Clases `Service` para manejar la lógica de ABM sobre listas en memoria.
   - Uso de **interfaces** para desacoplar la lógica de negocio.

5. **Login**
   - Validación de credenciales contra la lista de usuarios.
   - Redirección a la página principal al iniciar sesión correctamente.

6. **UI con Bootstrap 5**
   - Uso de **Cards** para mostrar datos de detalle.
   - Uso de **Tablas** para listados.

7. **Menú principal con íconos de Bootstrap**
   - Menú inferior estilo app móvil.
   - Íconos de [Bootstrap Icons](https://icons.getbootstrap.com/).

---

## 🛠️ Tecnologías utilizadas

- **.NET 8 MAUI Blazor Hybrid**
- **C# 12**
- **Bootstrap 5**
- **Bootstrap Icons**

---

## 📦 Instalación y ejecución

### 1️ Clonar el repositorio
bash
git clone https://github.com/usuario/biblioteca-app.git
cd biblioteca-app

### 2️ Restaurar dependencias
dotnet restore

### 3️ Ejecutar en emulador Android/iOS o como app de escritorio
dotnet build
dotnet maui run

---

## 💻 Uso
Pantalla de Login → Ingresar email y clave para acceder.

Menú principal → Navegar entre Usuarios, Libros y Logout.

Usuarios → Crear, editar o eliminar usuarios con imágenes.

Libros → Gestionar libros con sus portadas.

Detalle → Ver información completa y editar.




