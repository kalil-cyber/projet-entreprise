# 🎓 Système de Gestion d'Entreprise - Projet Scolaire

Application web ASP.NET Core MVC pour la gestion des départements, salariés et projets d'une entreprise.

## 🚀 Fonctionnalités

- **Gestion des Départements** : Créer, modifier et supprimer des départements
- **Gestion des Salariés** : Gérer les informations des employés avec leurs départements
- **Gestion des Projets** : Suivre les projets avec dates de début et fin
- **Interface Moderne** : Design responsive avec Bootstrap 5 et icônes Bootstrap Icons
- **Statistiques** : Tableau de bord avec statistiques en temps réel

## 🛠️ Technologies

- ASP.NET Core 6.0
- Entity Framework Core
- SQLite (base de données)
- Bootstrap 5
- Bootstrap Icons

## 📋 Installation Locale

1. Cloner le repository
```bash
git clone https://github.com/kalil-cyber/projet-entreprise.git
cd projet-entreprise
```

2. Restaurer les packages
```bash
dotnet restore
```

3. Créer la base de données
```bash
dotnet ef database update
```

4. Lancer l'application
```bash
dotnet run
```

L'application sera accessible sur `https://localhost:7229` ou `http://localhost:5008`

## 🌐 Déploiement pour Projet Scolaire

**Aucune configuration Docker nécessaire !** Railway et Render détectent automatiquement .NET.

### Option 1 : Railway.app (Recommandé - 5 minutes)

1. Créez un compte sur [railway.app](https://railway.app) (gratuit avec GitHub)
2. Poussez votre code sur GitHub
3. Sur Railway : "New Project" → "Deploy from GitHub repo"
4. Sélectionnez votre repository
5. Railway détecte automatiquement .NET et déploie !

**Votre lien :** `https://votre-projet.up.railway.app`

### Option 2 : Render.com (Gratuit)

1. Allez sur [render.com](https://render.com)
2. Créez un compte
3. "New" → "Web Service"
4. Connectez votre GitHub
5. Render détecte automatiquement .NET et déploie

**Votre lien :** `https://votre-projet.onrender.com`

## 📝 Structure du Projet

```
mac/
├── Controllers/          # Contrôleurs MVC
│   ├── HomeController.cs
│   ├── DepartementsController.cs
│   ├── SalariesController.cs
│   └── ProjetsController.cs
├── Models/              # Modèles de données
│   ├── Departement.cs
│   ├── Salarie.cs
│   └── Projet.cs
├── Views/               # Vues Razor
│   ├── Home/
│   ├── Departements/
│   ├── Salaries/
│   └── Projets/
├── Data/                # Contexte Entity Framework
│   └── ApplicationDbContext.cs
└── wwwroot/            # Fichiers statiques (CSS, JS)
```

## 📸 Captures d'écran

L'application dispose d'une interface moderne avec :
- Navigation intuitive
- Cartes statistiques sur la page d'accueil
- Tableaux interactifs
- Formulaires avec validation
- Design responsive pour mobile

## 📄 Licence

Ce projet est réalisé dans le cadre d'un projet scolaire.
