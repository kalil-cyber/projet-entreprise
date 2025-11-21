# 📡 Documentation API - Système de Gestion d'Entreprise

## Base URL
```
http://localhost:5008/api
ou
https://localhost:7229/api
```

## Endpoints Disponibles

### 📊 Statistiques

#### GET /api/StatsApi
Retourne toutes les statistiques de l'application.

**Réponse :**
```json
{
  "totalDepartements": 5,
  "totalSalaries": 20,
  "totalProjets": 8,
  "salaireMoyen": 45000.50,
  "projetsEnCours": 3,
  "projetsTermines": 2,
  "projetsAVenir": 3,
  "departementsAvecSalaries": 4
}
```

**Exemple :**
```bash
curl http://localhost:5008/api/StatsApi
```

---

### 🏢 Départements

#### GET /api/DepartementsApi
Retourne la liste de tous les départements.

**Réponse :**
```json
[
  {
    "id": 1,
    "nom": "Informatique",
    "nombreSalaries": 5,
    "createdAt": "2024-01-15T10:00:00",
    "updatedAt": "2024-01-15T10:00:00"
  }
]
```

**Exemple :**
```bash
curl http://localhost:5008/api/DepartementsApi
```

#### GET /api/DepartementsApi/{id}
Retourne les détails d'un département spécifique avec ses salariés.

**Paramètres :**
- `id` (int) : ID du département

**Réponse :**
```json
{
  "id": 1,
  "nom": "Informatique",
  "nombreSalaries": 5,
  "salaries": [
    {
      "id": 1,
      "nom": "Dupont",
      "prenom": "Jean",
      "age": 30,
      "salaire": 50000
    }
  ],
  "createdAt": "2024-01-15T10:00:00",
  "updatedAt": "2024-01-15T10:00:00"
}
```

**Exemple :**
```bash
curl http://localhost:5008/api/DepartementsApi/1
```

---

### 👥 Salariés

#### GET /api/SalariesApi
Retourne la liste de tous les salariés.

**Réponse :**
```json
[
  {
    "id": 1,
    "nom": "Dupont",
    "prenom": "Jean",
    "age": 30,
    "salaire": 50000,
    "departement": {
      "id": 1,
      "nom": "Informatique"
    },
    "createdAt": "2024-01-15T10:00:00",
    "updatedAt": "2024-01-15T10:00:00"
  }
]
```

**Exemple :**
```bash
curl http://localhost:5008/api/SalariesApi
```

#### GET /api/SalariesApi/{id}
Retourne les détails d'un salarié spécifique.

**Paramètres :**
- `id` (int) : ID du salarié

**Réponse :**
```json
{
  "id": 1,
  "nom": "Dupont",
  "prenom": "Jean",
  "age": 30,
  "salaire": 50000,
  "departement": {
    "id": 1,
    "nom": "Informatique"
  },
  "createdAt": "2024-01-15T10:00:00",
  "updatedAt": "2024-01-15T10:00:00"
}
```

**Exemple :**
```bash
curl http://localhost:5008/api/SalariesApi/1
```

---

### 📁 Projets

#### GET /api/ProjetsApi
Retourne la liste de tous les projets.

**Réponse :**
```json
[
  {
    "id": 1,
    "nom": "Développement Application Web",
    "description": "Création d'une application web moderne",
    "dateDebut": "2024-01-01",
    "dateFin": "2024-06-30",
    "dureeJours": 181,
    "statut": "En cours",
    "createdAt": "2024-01-15T10:00:00",
    "updatedAt": "2024-01-15T10:00:00"
  }
]
```

**Exemple :**
```bash
curl http://localhost:5008/api/ProjetsApi
```

#### GET /api/ProjetsApi/{id}
Retourne les détails d'un projet spécifique.

**Paramètres :**
- `id` (int) : ID du projet

**Réponse :**
```json
{
  "id": 1,
  "nom": "Développement Application Web",
  "description": "Création d'une application web moderne",
  "dateDebut": "2024-01-01",
  "dateFin": "2024-06-30",
  "dureeJours": 181,
  "statut": "En cours",
  "createdAt": "2024-01-15T10:00:00",
  "updatedAt": "2024-01-15T10:00:00"
}
```

**Exemple :**
```bash
curl http://localhost:5008/api/ProjetsApi/1
```

---

## Codes de Réponse HTTP

- **200 OK** : Requête réussie
- **404 Not Found** : Ressource non trouvée
- **500 Internal Server Error** : Erreur serveur

## Format de Réponse

Toutes les réponses sont au format **JSON** avec l'en-tête `Content-Type: application/json`.

## Exemples de Test

### Avec curl (Windows PowerShell)
```powershell
# Statistiques
Invoke-WebRequest -Uri "http://localhost:5008/api/StatsApi" | Select-Object -ExpandProperty Content

# Liste des départements
Invoke-WebRequest -Uri "http://localhost:5008/api/DepartementsApi" | Select-Object -ExpandProperty Content

# Détails d'un département
Invoke-WebRequest -Uri "http://localhost:5008/api/DepartementsApi/1" | Select-Object -ExpandProperty Content
```

### Avec le navigateur
Ouvrez simplement l'URL dans votre navigateur :
- http://localhost:5008/api/StatsApi
- http://localhost:5008/api/DepartementsApi
- http://localhost:5008/api/SalariesApi
- http://localhost:5008/api/ProjetsApi

### Avec Postman ou Insomnia
Importez les endpoints et testez-les avec ces outils.

---

## Notes

- Tous les endpoints sont en **lecture seule** (GET uniquement)
- Les données sont retournées en temps réel depuis la base de données
- Les dates sont formatées en ISO 8601 (yyyy-MM-dd)
- Les montants sont en format décimal

