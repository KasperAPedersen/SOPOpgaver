DROP DATABASE IF EXISTS downloaderen;
CREATE DATABASE downloaderen;
USE downloaderen;

CREATE TABLE `users` (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Username varchar(50) NOT NULL,
  PasswordHash varbinary(64) NOT NULL,
  Salt varbinary(16) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE `downloads` (
  id int(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL,
  url text NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (user_id) REFERENCES users(Id)
);