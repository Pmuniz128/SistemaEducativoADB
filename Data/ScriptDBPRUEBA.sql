CREATE TABLE Estudiantes (
    id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
);


INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Gomez', 'Ana', 22);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Rodriguez', 'Carlos', 24);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Lopez', 'Maria', 21);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Perez', 'Luis', 23);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Sanchez', 'Elena', 27);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Diaz', 'Jorge', 25);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Morales', 'Lucia', 26);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Vargas', 'Andres', 29);
INSERT INTO Estudiantes(LastName, FirstName, Age) VALUES ('Castro', 'Sofia', 22);
