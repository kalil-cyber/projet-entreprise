# 🧪 Instructions pour Tester les API

## ⚠️ IMPORTANT : Redémarrer l'Application

L'application **DOIT être redémarrée** pour que les nouveaux contrôleurs API soient chargés.

### Étapes :

1. **Arrêter l'application actuelle**
   - Dans le terminal où `dotnet run` tourne, appuyez sur `Ctrl+C`

2. **Relancer l'application**
   ```bash
   dotnet run
   ```

3. **Attendre que l'application démarre**
   - Vous devriez voir : `Now listening on: http://localhost:5008`

4. **Tester les API dans le navigateur**

   Ouvrez ces URLs dans votre navigateur :
   
   - ✅ **Statistiques** : http://localhost:5008/api/StatsApi
   - ✅ **Départements** : http://localhost:5008/api/DepartementsApi
   - ✅ **Salariés** : http://localhost:5008/api/SalariesApi
   - ✅ **Projets** : http://localhost:5008/api/ProjetsApi

5. **Vérifier le résultat**
   - Si vous voyez du **JSON**, les API fonctionnent ! ✅
   - Si vous voyez **404**, l'application n'a pas été redémarrée

---

## 🔍 Vérification Rapide

### Test dans le Navigateur

1. Ouvrez Chrome/Firefox/Edge
2. Allez sur : `http://localhost:5008/api/StatsApi`
3. Vous devriez voir quelque chose comme :
   ```json
   {
     "totalDepartements": 0,
     "totalSalaries": 0,
     "totalProjets": 0,
     "salaireMoyen": 0,
     ...
   }
   ```

### Test avec PowerShell

```powershell
# Après avoir redémarré l'application
Invoke-WebRequest -Uri "http://localhost:5008/api/StatsApi" | Select-Object StatusCode, Content
```

---

## ✅ Si ça fonctionne

Vous verrez du JSON avec les données. Les API sont opérationnelles !

---

## ❌ Si ça ne fonctionne pas

1. Vérifiez que l'application est bien démarrée
2. Vérifiez l'URL (doit être exactement `/api/StatsApi`)
3. Redémarrez l'application complètement
4. Vérifiez les logs de l'application pour voir les erreurs

---

## 📝 Note

Les contrôleurs API sont dans `Controllers/Api/` et sont automatiquement découverts par ASP.NET Core une fois l'application redémarrée.

