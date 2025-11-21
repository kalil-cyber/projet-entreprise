# 🧪 Test des API

## Instructions pour Tester les API

### 1. Redémarrer l'application
L'application doit être redémarrée pour charger les nouveaux contrôleurs API.

```bash
# Arrêter l'application actuelle (Ctrl+C dans le terminal)
# Puis relancer :
dotnet run
```

### 2. Tester avec le Navigateur

Ouvrez ces URLs dans votre navigateur :

#### ✅ Statistiques
```
http://localhost:5008/api/StatsApi
```

#### ✅ Départements
```
http://localhost:5008/api/DepartementsApi
http://localhost:5008/api/DepartementsApi/1
```

#### ✅ Salariés
```
http://localhost:5008/api/SalariesApi
http://localhost:5008/api/SalariesApi/1
```

#### ✅ Projets
```
http://localhost:5008/api/ProjetsApi
http://localhost:5008/api/ProjetsApi/1
```

### 3. Tester avec PowerShell

```powershell
# Statistiques
$response = Invoke-WebRequest -Uri "http://localhost:5008/api/StatsApi"
$response.Content | ConvertFrom-Json

# Liste des départements
$response = Invoke-WebRequest -Uri "http://localhost:5008/api/DepartementsApi"
$response.Content | ConvertFrom-Json

# Détails d'un département (remplacez 1 par un ID existant)
$response = Invoke-WebRequest -Uri "http://localhost:5008/api/DepartementsApi/1"
$response.Content | ConvertFrom-Json
```

### 4. Vérifier que ça fonctionne

Si vous voyez du JSON dans votre navigateur ou dans PowerShell, **les API fonctionnent !** ✅

### 5. Format de Réponse Attendu

Les API retournent du JSON, par exemple :

```json
{
  "totalDepartements": 0,
  "totalSalaries": 0,
  "totalProjets": 0,
  "salaireMoyen": 0,
  "projetsEnCours": 0,
  "projetsTermines": 0,
  "projetsAVenir": 0,
  "departementsAvecSalaries": 0
}
```

---

## ✅ Checklist de Vérification

- [ ] Application redémarrée avec `dotnet run`
- [ ] Test de `/api/StatsApi` dans le navigateur
- [ ] Test de `/api/DepartementsApi` dans le navigateur
- [ ] Test de `/api/SalariesApi` dans le navigateur
- [ ] Test de `/api/ProjetsApi` dans le navigateur
- [ ] Vérification que le JSON s'affiche correctement

---

## 🐛 En cas d'erreur 404

1. Vérifiez que l'application est bien démarrée
2. Vérifiez l'URL (doit commencer par `/api/`)
3. Vérifiez que les contrôleurs API sont bien dans le dossier `Controllers/Api/`
4. Redémarrez l'application

---

## 📝 Notes

- Toutes les API sont en **lecture seule** (GET uniquement)
- Les données proviennent directement de la base de données
- Les réponses sont au format JSON
- Les dates sont formatées en ISO 8601

