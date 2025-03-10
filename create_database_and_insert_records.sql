DROP TABLE IF EXISTS FactureArticle;
DROP TABLE IF EXISTS Facture;
DROP TABLE IF EXISTS Article;
DROP TABLE IF EXISTS Client;
DROP TABLE IF EXISTS Evenement;
DROP TABLE IF EXISTS Vendeur;

CREATE TABLE IF NOT EXISTS `Client` (
	`NumClient` integer  NOT NULL UNIQUE,
	`CodePostal` varchar(10) NOT NULL,
	`Nom` TEXT NOT NULL,
	`Prenom` TEXT NOT NULL,
	`DateDeNaissance` datetime NOT NULL,
	`Adresse` TEXT NOT NULL,
 PRIMARY KEY (NumClient AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS `Article` (
	`NumArticle` integer NOT NULL UNIQUE,
	`Nom` TEXT NOT NULL,
	`Prix` decimal(10,2) NOT NULL,
 PRIMARY KEY (NumArticle AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS `Vendeur` (
	`NumVendeur` integer NOT NULL UNIQUE,
	`Login` TEXT NOT NULL,
	`MotDePasse` TEXT NOT NULL,
	`Nom` TEXT NOT NULL,
 PRIMARY KEY (NumVendeur AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS `Facture` (
	`NumFacture` integer NOT NULL UNIQUE,
	`DateFacture` datetime NOT NULL,
	`NumClient` INTEGER NOT NULL,
	`NumVendeur` INTEGER NOT NULL,
FOREIGN KEY(`NumClient`) REFERENCES `Client`(`NumClient`),
FOREIGN KEY(`NumVendeur`) REFERENCES `Vendeur`(`NumVendeur`),
 PRIMARY KEY (NumFacture AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS `FactureArticle` (
	`NumFactureArticle` integer NOT NULL UNIQUE,
	`NumFacture` INTEGER NOT NULL,
	`NumArticle` INTEGER NOT NULL,
	`Quantite` INTEGER NOT NULL,
	`Prix` REAL NOT NULL,
FOREIGN KEY(`NumFacture`) REFERENCES `Facture`(`NumFacture`),
FOREIGN KEY(`NumArticle`) REFERENCES `Article`(`NumArticle`),
 PRIMARY KEY (NumFactureArticle AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS `Evenement` (
	`NumEvenement` integer NOT NULL UNIQUE,
	`DateEvenement` datetime NOT NULL,
	`Description` TEXT NOT NULL,
	`NumVendeur` INTEGER NOT NULL,
	`TypeEvenement` TEXT NOT NULL,
FOREIGN KEY(`NumVendeur`) REFERENCES `Vendeur`(`NumVendeur`),
 PRIMARY KEY (NumEvenement AUTOINCREMENT)
);
/*ajout d'enregistrements*/

INSERT INTO Client (CodePostal, Nom, Prenom, DateDeNaissance, Adresse) VALUES ('1000', 'Bolomey', 'Jean', '1990-05-23', 'rue des Tours 3');
INSERT INTO Client (CodePostal, Nom, Prenom, DateDeNaissance, Adresse) VALUES ('1000', 'Pittet', 'Quentin', '1996-07-13', 'chemin des Violettes 12');
INSERT INTO Article (Nom, Prix) VALUES ('intel core vpro', 1234.55);
INSERT INTO Article (Nom, Prix) VALUES ('amd athlon', 234.90);
INSERT INTO Article (Nom, Prix) VALUES ('intel i7', 450);
INSERT INTO Vendeur (Login, MotDePasse, Nom) VALUES ('toto', 'toto', 'Toto');
INSERT INTO Vendeur (Login, MotDePasse, Nom) VALUES ('vendeur1', 'vendeur1', 'Vendeur1');
INSERT INTO Evenement (DateEvenement, Description, NumVendeur, TypeEvenement) VALUES ('2025-02-20 15:12:37', 'Connexion', 2, 'INFO');
INSERT INTO Evenement (DateEvenement, Description, NumVendeur, TypeEvenement) VALUES ('2025-02-20 16:12:37', 'Déconnexion', 2, 'INFO');
INSERT INTO Facture (DateFacture, NumClient, NumVendeur) VALUES ('2025-01-19', 1, 2);
INSERT INTO Facture (DateFacture, NumClient, NumVendeur) VALUES ('2025-02-19', 2, 2);
INSERT INTO FactureArticle (NumFacture, NumArticle, Quantite, Prix) VALUES (1, 2, 3, 234.50);
INSERT INTO FactureArticle (NumFacture, NumArticle, Quantite, Prix) VALUES (2, 1, 4, 1230);
INSERT INTO FactureArticle (NumFacture, NumArticle, Quantite, Prix) VALUES (1, 3, 2, 451.15);