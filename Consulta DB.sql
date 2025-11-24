
CREATE DATABASE DBEstacionamiento;
 GO
 USE DBEstacionamiento;
 GO

CREATE TABLE Conductor (
    IdConductor INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    DNI VARCHAR(15),
    Telefono VARCHAR(15),
    Correo VARCHAR(100)
);

CREATE TABLE Espacio (
    IdEspacio INT PRIMARY KEY,
    Ocupado BIT NOT NULL DEFAULT 0,
    PlacaVehiculo VARCHAR(10) NULL -- Almacena la placa que ocupa el espacio
);

CREATE TABLE Vehiculo (
    IdVehiculo INT PRIMARY KEY IDENTITY(1,1),
    Placa VARCHAR(10) NOT NULL UNIQUE,
    Modelo VARCHAR(50),
    Color VARCHAR(50),
    HoraEntrada DATETIME NOT NULL,
    
    -- IdEspacio AHORA PERMITE NULL (para vehículos 'pendientes')
    IdEspacio INT NULL, 
    IdConductor INT NOT NULL,
    
    -- Definiciones de Claves Foráneas
    FOREIGN KEY (IdConductor) REFERENCES Conductor(IdConductor),
    FOREIGN KEY (IdEspacio) REFERENCES Espacio(IdEspacio)
);

CREATE TABLE Boleta (
    IdBoleta INT PRIMARY KEY IDENTITY(1,1),
    IdVehiculo INT, -- Se mantiene la FK al Vehículo
    HoraEntrada DATETIME NOT NULL,
    HoraSalida DATETIME NOT NULL,
    Monto DECIMAL(10, 2) NOT NULL
    -- NOTA: Como el vehículo es ELIMINADO de la tabla Vehiculo al salir, 
    -- no se define una clave foránea (ON DELETE CASCADE) para evitar errores.
);

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL, -- Clave sin hash para la demo ('1234')
    Rol VARCHAR(50)
);



INSERT INTO Espacio (IdEspacio, Ocupado, PlacaVehiculo) VALUES (1, 0, NULL);
INSERT INTO Espacio (IdEspacio, Ocupado, PlacaVehiculo) VALUES (2, 0, NULL);
INSERT INTO Espacio (IdEspacio, Ocupado, PlacaVehiculo) VALUES (3, 0, NULL);
INSERT INTO Espacio (IdEspacio, Ocupado, PlacaVehiculo) VALUES (4, 0, NULL);
INSERT INTO Espacio (IdEspacio, Ocupado, PlacaVehiculo) VALUES (5, 0, NULL);

INSERT INTO Usuario (NombreUsuario, Contrasena, Rol) 
VALUES ('admin', '1234', 'Administrador');