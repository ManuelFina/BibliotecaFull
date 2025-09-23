IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Libros] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [Imagen] nvarchar(max) NOT NULL,
    [AñoPublicacion] int NOT NULL,
    CONSTRAINT [PK_Libros] PRIMARY KEY ([Id])
);

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Clave] nvarchar(max) NOT NULL,
    [Rol] nvarchar(max) NOT NULL,
    [Activo] bit NOT NULL,
    [Imagen] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250923205456_Inicial', N'9.0.9');

COMMIT;
GO

