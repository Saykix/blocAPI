CREATE TABLE site (
  IdSite int AUTO_INCREMENT,
  ville varchar(255) NOT NULL,
  adresse varchar(255) NOT NULL,
  codePostal varchar(255) NOT NULL,
  PRIMARY KEY(IdSite)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE service (
  IdService int AUTO_INCREMENT,
  nomService varchar(255) NOT NULL,
  PRIMARY KEY(IdService)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE employer (
  IdEmployer int AUTO_INCREMENT,
  nom varchar(255) NOT NULL,
  prenom varchar(255) NOT NULL,
  fixe varchar(255) NOT NULL,
  portable varchar(255) NOT NULL,
  email varchar(255) NOT NULL,
  employerService int NOT NULL,
  employerSite int NOT NULL,
  PRIMARY KEY(IdEmployer),
  FOREIGN KEY (employerService) REFERENCES service(IdService),
  FOREIGN KEY (employerSite) REFERENCES site(IdSite)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;