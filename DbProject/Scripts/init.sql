DROP DATABASE MyProject;
CREATE DATABASE MyProject;

CREATE TABLE Doctors
(
    Id INT PRIMARY KEY,
    Name VARCHAR NOT NULL,
    Surname VARCHAR NOT NULL,
    Specialization VARCHAR NOT NULL,
    Experience INT NOT NULL
);

CREATE TABLE Patients
(
    Id INT PRIMARY KEY,
    DoctorId INT FOREIGN KEY REFERENCES Doctors(Id) NOT NULL,
    Name NVARCHAR(MAX) NOT NULL,
    Surname NVARCHAR(MAX) NOT NULL,
    Disease NVARCHAR(MAX) NOT NULL
);