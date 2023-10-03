Create table Matricula
(
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    DNI VARCHAR2(8),
    CodAlumno varchar2(15),   
    Nombres varchar2(30),   
    Apellidos varchar2(30),  
    IdCursoSeccion int,
    Tipo varchar2(20),
    Estado numeric(1),
    FechaReg DATE,
    FechaBaja DATE
);

Create table Curso
(
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    Descripcion VARCHAR2(30),
    Creditos int
);

Create table Seccion
(
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    Nombre VARCHAR2(50),
    Estado numeric(1)
);

Create table CursoSeccion
(
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    IdCurso INT,
    IdSeccion int,
    Vacantes int
);

select * from Curso;

INSERT INTO Curso (Descripcion, Creditos) VALUES('curso 1', 2);
INSERT INTO Curso (Descripcion, Creditos) VALUES('curso 2', 2);
INSERT INTO Curso (Descripcion, Creditos) VALUES('curso 3', 3);
INSERT INTO Curso (Descripcion, Creditos) VALUES('curso 4', 5);
INSERT INTO Curso (Descripcion, Creditos) VALUES('curso 5', 6);

INSERT INTO Seccion (Nombre) VALUES('Seccion A');
INSERT INTO Seccion (Nombre) VALUES('Seccion B');
INSERT INTO Seccion (Nombre) VALUES('Seccion C');

INSERT INTO CursoSeccion (IDCURSO, IDSECCION, VACANTES) VALUES(1,1,4);
INSERT INTO CursoSeccion (IDCURSO, IDSECCION, VACANTES) VALUES(2,2,1);
INSERT INTO CursoSeccion (IDCURSO, IDSECCION, VACANTES) VALUES(3,2,3);
INSERT INTO CursoSeccion (IDCURSO, IDSECCION, VACANTES) VALUES(4,3,2);

insert into Matricula 
(DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg)
VALUES
('45964783', 'A0001', 'Marvin Max', 'Meza Odar', 1, 'Presencial', 1, CURRENT_DATE);

insert into Matricula 
(DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg)
VALUES
('56461568', 'A0002', 'Jorge', 'Lopez Savedra', 2, 'A distancia', 1, CURRENT_DATE);

insert into Matricula 
(DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg)
VALUES
('56461789', 'A0003', 'Pedro', 'Savaleta Ponce', 3, 'Presencial', 1, CURRENT_DATE);

insert into Matricula 
(DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg)
VALUES
('78945689', 'A0004', 'Maria', 'Ramirez Gonzales', 4, 'Presencial', 1, CURRENT_DATE);

insert into Matricula 
(DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg)
VALUES
('65498158', 'A0005', 'Julia', 'Perez Deza', 1, 'Presencial', 1, CURRENT_DATE);