DROP DATABASE IF EXISTS MyProject;
CREATE DATABASE MyProject;
USE MyProject;

CREATE TABLE Doctors
(
    Id INT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    Specialization VARCHAR(20) NOT NULL,
    Experience INT NOT NULL
);

CREATE TABLE Treatments
(
    Diagnosis VARCHAR(20) PRIMARY KEY, 
    Date_of_starting DATE NOT NULL, 
    Date_of_finishing DATE NOT NULL,
    DoctorId INT NOT NULL,
    CurrentState VARCHAR(20) NOT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);

CREATE TABLE Patients
(
    Id INT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    Date_of_birth DATE NOT NULL,
    Diagnosis VARCHAR(20) NOT NULL,
    FOREIGN KEY (Diagnosis) REFERENCES Treatments(Diagnosis)
);

INSERT INTO Doctors (Id, Name, Specialization, Experience) VALUES (1, 'Doe', 'Urolog', 5);