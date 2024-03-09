CREATE DATABASE PARCIAL1B;

CREATE TABLE ElementosPorPlatoID (
	ElementoPorPlatoID INT PRIMARY KEY,
	EmpresaID INT,
	PlatoiID INT,
	ElementoID INT,
	Cantidad INT,
	Estado INT
);

CREATE TABLE Platos (
	PlatoID INT PRIMARY KEY,
	EmpresaID INT,
	GrupoID INT,
	NombrePlato VARCHAR(20),
	DescripcionPlato VARCHAR(75),
	Precio FLOAT
);

CREATE TABLE PlatosPorCombo (
	PlatosPorComboID INT PRIMARY KEY,
	EmpresaID INT,
	ComboID INT,
	PlatoID INT,
	Estado INT
);

CREATE TABLE Elementos (
	ElementosID INT PRIMARY KEY,
	EmpresaID INT,
	Elemento VARCHAR(50),
	CantidadMinima INT,
	UnidadMedida FLOAT,
	Costo FLOAT,
	Estado INT
);