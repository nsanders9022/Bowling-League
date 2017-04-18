CREATE database League
GO
USE League
GO
CREATE TABLE Divisions
(
  divisionId int NOT NULL IDENTITY(1, 1),
  skill_level nchar(255) NOT NULL,
  max_team int NOT NULL,
  description nchar(255) NOT NULL
)
go

ALTER TABLE Divisions ADD CONSTRAINT PK_Divisions
  PRIMARY KEY (divisionId)
go

CREATE TABLE Players
(
  playerId int NOT NULL IDENTITY(1, 1),
  name nchar(255) NOT NULL,
  teamId int NULL
)
go

ALTER TABLE Players ADD CONSTRAINT PK_Players
  PRIMARY KEY (playerId)
go

CREATE TABLE Teams
(
  teamId int NOT NULL IDENTITY(1, 1),
  name nchar(255) NOT NULL,
  divisionId int NOT NULL
)
go

ALTER TABLE Teams ADD CONSTRAINT PK_Teams
  PRIMARY KEY (teamId)
go

ALTER TABLE Players ADD CONSTRAINT FK_Players_Teams
  FOREIGN KEY (teamId) REFERENCES Teams (teamId)
go

ALTER TABLE Teams ADD CONSTRAINT FK_Teams_Divisions
  FOREIGN KEY (divisionId) REFERENCES Divisions (divisionId)
go