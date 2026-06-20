# Menuiserie Web App

## Présentation

Application web de gestion d'une menuiserie développée dans le cadre du cours Angular / .NET.

L'application permet :

* Gestion des clients
* Gestion des produits
* Gestion des catégories
* Gestion des dimensions
* Gestion du personnel
* Gestion des chantiers
* Gestion des commandes
* Gestion des détails de commandes
* Authentification utilisateur via JWT

---

# Technologies utilisées

## Frontend

* Angular
* TypeScript
* Angular Router
* Angular Signals
* HttpClient

## Backend

* ASP.NET Core (.NET)
* Architecture 3 couches :

  * API
  * Core
  * Infrastructure
* Dapper
* SQLite
* JWT Authentication

---

# Prérequis

Installer :

* .NET 10 SDK
* Node.js
* Angular CLI
* Git

Vérification :

```bash
dotnet --version
node --version
ng version
```

---

# Structure du projet

```txt
Menuiserie-web-app
│
├── Frontend
│
└── Backend
    ├── Api
    ├── Core
    └── Infrastructure
```

---

# Base de données

Le projet utilise SQLite.

Le script de création de la base se trouve dans :

```txt
Backend/Infrastructure/db.sql
```

La base est créée automatiquement au premier démarrage de l'API.

---

# Configuration

## Backend

Fichier :

```txt
Backend/Api/appsettings.json
```

Chaîne de connexion :

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=../Infrastructure/menuiserie.db"
}
```

---

# Lancement du Backend

Depuis la racine du projet :

```bash
cd Backend
dotnet restore
dotnet build
dotnet run --project Api
```

L'API démarre sur :

```txt
http://localhost:5110
```

Documentation OpenAPI :

```txt
http://localhost:5110/openapi/v1.json
```

---

# Lancement du Frontend

Depuis la racine du projet :

```bash
cd Frontend
npm install
ng serve
```

L'application démarre sur :

```txt
http://localhost:4200
```

---

# Authentification

Créer un compte :

```txt
http://localhost:4200/register
```

Connexion :

```txt
http://localhost:4200/login
```

Compte de démonstration :

```txt
Email : peter@test.be
Mot de passe : 123456
```

---

# Fonctionnalités

* Authentification JWT
* Gestion des clients
* Gestion des produits
* Gestion des catégories
* Gestion des dimensions
* Gestion du personnel
* Gestion des chantiers
* Gestion des commandes
* Gestion des détails de commandes

---

# Nettoyage avant remise

Ne pas inclure :

```txt
Frontend/node_modules
Frontend/.angular

Backend/**/bin
Backend/**/obj

Backend/Infrastructure/menuiserie.db
```

---

# Auteur

J.Pierre Nsengiyumva

Projet réalisé dans le cadre du cours Angular / .NET.
