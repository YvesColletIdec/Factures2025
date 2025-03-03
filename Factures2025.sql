DROP TABLE IF EXISTS FactureArticle;
DROP TABLE IF EXISTS Facture;
DROP TABLE IF EXISTS Article;
DROP TABLE IF EXISTS Client;
DROP TABLE IF EXISTS Vendeur;
DROP TABLE IF EXISTS Evenement;
CREATE TABLE IF NOT EXISTS `Facture` (
	`NumFacture` integer NOT NULL UNIQUE,
	`DateFacture` datetime NOT NULL,
	`NumClient` INTEGER NOT NULL,
	`NumVendeur` INTEGER NOT NULL,
FOREIGN KEY(`NumClient`) REFERENCES `Client`(`NumClient`),
FOREIGN KEY(`NumVendeur`) REFERENCES `Vendeur`(`NumVendeur`),
 PRIMARY KEY (NumFacture AUTOINCREMENT)
);
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