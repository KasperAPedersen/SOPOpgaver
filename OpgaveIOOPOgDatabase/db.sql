DROP DATABASE IF EXISTS OOP2;
CREATE DATABASE OOP2;
USE OOP2;

CREATE TABLE city (
  PostalCode INT PRIMARY KEY,
  CityName VARCHAR(255)
);

CREATE TABLE schools (
  educationID INT AUTO_INCREMENT PRIMARY KEY,
  schoolsName VARCHAR(255)
);

CREATE TABLE education (
  educationID INT PRIMARY KEY,
  educationEnd DATE,
  FOREIGN KEY (educationID) REFERENCES schools(educationID)
);

CREATE TABLE jobs (
  JobID INT AUTO_INCREMENT PRIMARY KEY,
  JobName VARCHAR(255)
);

CREATE TABLE Employment (
  EmploymentID INT PRIMARY KEY,
  EmploymentStart DATE,
  EmploymentEnd DATE,
  FOREIGN KEY (EmploymentID) REFERENCES jobs(JobID)
);

CREATE TABLE customer (
  id int AUTO_INCREMENT PRIMARY KEY,
  FirstName VARCHAR(255),
  LastName VARCHAR(255),
  Street VARCHAR(255),
  PostalID INT,
  EducationID INT,
  EmploymentID INT,
  FOREIGN KEY (PostalID) REFERENCES city(PostalCode),
  FOREIGN KEY (EducationID) REFERENCES education(educationID),
  FOREIGN KEY (EmploymentID) REFERENCES Employment(EmploymentID)
);

-- Insert data into the tables
INSERT INTO city (PostalCode, CityName) VALUES (1000, 'København');
INSERT INTO schools (schoolsName) VALUES ('Københavns universitet');
INSERT INTO education (educationID, educationEnd) VALUES (1, '2020-01-01');
INSERT INTO jobs (JobName) VALUES ('Programmør');
INSERT INTO Employment (EmploymentID, EmploymentStart, EmploymentEnd) VALUES (1, '2020-01-01', '2022-01-01');
INSERT INTO customer (FirstName, LastName, Street, PostalID, EducationID, EmploymentID) VALUES ('John', 'Doe', 'johndoe street 13', 1000, 1, 1);