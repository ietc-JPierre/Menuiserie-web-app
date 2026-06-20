CREATE TABLE Type_client(
   Id_Type_client INTEGER PRIMARY KEY AUTOINCREMENT,
   nom_type TEXT NOT NULL
);

INSERT INTO Type_client(nom_type) VALUES
('Particulier'),
('Entreprise'),
('Administration');

CREATE TABLE Categorie(
   Id_Categorie INTEGER PRIMARY KEY AUTOINCREMENT,
   nom_categorie TEXT NOT NULL
);

INSERT INTO Categorie(nom_categorie) VALUES
('Porte'),
('Châssis'),
('Meuble');


CREATE TABLE Dimension(
   Id_Dimension INTEGER PRIMARY KEY AUTOINCREMENT,
   hauteur REAL NOT NULL,
   section REAL NOT NULL,
   largeur REAL NOT NULL
);

INSERT INTO Dimension(hauteur, section, largeur) VALUES
(210, 5, 90),
(120, 4, 100),
(200, 6, 80);


CREATE TABLE Personnel(
   Id_Personnel TEXT PRIMARY KEY,
   nom TEXT NOT NULL,
   role TEXT NOT NULL
);

CREATE TABLE Code_postal_chantier(
   code_postal TEXT PRIMARY KEY,
   ville TEXT NOT NULL
);

INSERT INTO Code_postal_chantier(code_postal, ville) VALUES
('1300', 'Wavre'),
('1348', 'Louvain-la-Neuve'),
('1000', 'Bruxelles');

CREATE TABLE Client(
   Id_Client INTEGER PRIMARY KEY AUTOINCREMENT,
   nom_client TEXT NOT NULL,
   adresse_client TEXT NOT NULL,
   tel_client TEXT NOT NULL,
   Id_Type_client INTEGER NOT NULL,
   FOREIGN KEY(Id_Type_client) REFERENCES Type_client(Id_Type_client)
);

INSERT INTO Client
(
    nom_client,
    adresse_client,
    tel_client,
    Id_Type_client
)
VALUES
(
    'Dupont',
    '10 Rue de Paris',
    '0600000000',
    1
);

CREATE TABLE Produit(
   Id_Produit INTEGER PRIMARY KEY AUTOINCREMENT,
   nom_produit TEXT NOT NULL,
   prix_unitaire_produit REAL NOT NULL,
   Id_Categorie INTEGER NOT NULL,
   FOREIGN KEY(Id_Categorie) REFERENCES Categorie(Id_Categorie)
);

CREATE TABLE Chantier(
   Id_Chantier INTEGER PRIMARY KEY AUTOINCREMENT,
   nom_chantier TEXT NOT NULL,
   rue TEXT NOT NULL,
   date_debut_chantier TEXT NOT NULL,
   date_fin_chantier TEXT NOT NULL,
   code_postal TEXT NOT NULL,
   FOREIGN KEY(code_postal) REFERENCES Code_postal_chantier(code_postal)
);

CREATE TABLE Commande(
   Id_Commande INTEGER PRIMARY KEY AUTOINCREMENT,
   date_commande TEXT NOT NULL,
   montant_paye REAL NOT NULL,
   reste_a_payer REAL NOT NULL,
   statut_commande TEXT NOT NULL,
   total_commande REAL NOT NULL,
   Id_Client INTEGER NOT NULL,
   FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client)
);

CREATE TABLE Client_chantier(
   Id_Client INTEGER,
   Id_Chantier INTEGER,
   PRIMARY KEY(Id_Client, Id_Chantier),
   FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client),
   FOREIGN KEY(Id_Chantier) REFERENCES Chantier(Id_Chantier)
);

CREATE TABLE Commande_produit(
   Id_Produit INTEGER,
   Id_Dimension INTEGER,
   Id_Commande INTEGER,
   quantite INTEGER NOT NULL,
   prix_unitaire REAL NOT NULL,
   PRIMARY KEY(Id_Produit, Id_Dimension, Id_Commande),
   FOREIGN KEY(Id_Produit) REFERENCES Produit(Id_Produit),
   FOREIGN KEY(Id_Dimension) REFERENCES Dimension(Id_Dimension),
   FOREIGN KEY(Id_Commande) REFERENCES Commande(Id_Commande)
);

CREATE TABLE Personnel_commande(
   Id_Personnel TEXT,
   Id_Commande INTEGER,
   PRIMARY KEY(Id_Personnel, Id_Commande),
   FOREIGN KEY(Id_Personnel) REFERENCES Personnel(Id_Personnel),
   FOREIGN KEY(Id_Commande) REFERENCES Commande(Id_Commande)
);

CREATE TABLE User(
   Id_User INTEGER PRIMARY KEY AUTOINCREMENT,
   username TEXT NOT NULL UNIQUE,
   email TEXT NOT NULL UNIQUE,
   password_hash TEXT NOT NULL,
   role TEXT NOT NULL
);



