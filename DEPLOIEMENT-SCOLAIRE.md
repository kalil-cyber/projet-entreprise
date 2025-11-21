# 🎓 Guide de Déploiement pour Projet Scolaire

## ⚡ Option 1 : Railway.app (RECOMMANDÉ - 5 minutes)

### Étapes simples :

1. **Créez un compte GitHub** (si vous n'en avez pas)
   - Allez sur [github.com](https://github.com) et créez un compte gratuit

2. **Poussez votre code sur GitHub**
   ```bash
   git init
   git add .
   git commit -m "Projet de gestion d'entreprise"
   git branch -M main
   # Créez un nouveau repository sur GitHub, puis :
   git remote add origin https://github.com/VOTRE-USERNAME/gestion-entreprise.git
   git push -u origin main
   ```

3. **Déployez sur Railway**
   - Allez sur [railway.app](https://railway.app)
   - Cliquez sur "Start a New Project"
   - Choisissez "Deploy from GitHub repo"
   - Autorisez Railway à accéder à votre compte GitHub
   - Sélectionnez votre repository
   - Railway détecte automatiquement .NET 6.0 et déploie !

4. **Votre lien sera :** `https://votre-projet.up.railway.app`

**C'est tout ! En 5 minutes vous avez un lien de déploiement !** 🎉

---

## 📋 Option 2 : Render.com (Gratuit aussi)

1. Allez sur [render.com](https://render.com)
2. Créez un compte gratuit
3. Cliquez sur "New" → "Web Service"
4. Connectez votre compte GitHub
5. Sélectionnez votre repository
6. Render détecte automatiquement le projet .NET 6.0
7. Cliquez sur "Create Web Service"

**Votre URL :** `https://votre-projet.onrender.com`

**Note :** Render peut être un peu lent au démarrage (cold start), mais c'est gratuit !

---

## 🎯 Pour votre Présentation

**Donnez ce lien à votre professeur :**
- Railway : `https://[nom-projet].up.railway.app`
- Render : `https://[nom-projet].onrender.com`

**Exemple de présentation :**
> "J'ai développé une application de gestion d'entreprise avec ASP.NET Core 6.0 MVC. 
> L'application est déployée et accessible en ligne à l'adresse : 
> [votre-lien]"

---

## ⚠️ Notes Importantes

- **Railway** : Gratuit avec 500 heures/mois (plus que suffisant pour un projet scolaire)
- **Render** : Gratuit mais peut être lent au premier démarrage
- Les deux sont parfaits pour des projets scolaires !
- La base de données SQLite sera créée automatiquement lors du premier lancement
- **.NET 6.0** est automatiquement détecté par les deux plateformes

---

## 🎓 Alternative : Démonstration Locale

Si votre professeur accepte une démonstration en direct sur votre ordinateur :

```bash
# Dans le dossier du projet
dotnet run
```

L'application sera accessible sur : `http://localhost:5008`

**Montrez simplement l'application qui tourne sur votre ordinateur !**

---

## 📝 Checklist de Déploiement

- [ ] Code poussé sur GitHub
- [ ] Compte créé sur Railway ou Render
- [ ] Projet déployé
- [ ] Lien testé et fonctionnel
- [ ] Prêt pour la présentation ! 🎉

---

## 🚀 Commandes Rapides

```bash
# 1. Initialiser Git
git init
git add .
git commit -m "Projet scolaire - Gestion d'entreprise"

# 2. Créer repo GitHub (via interface web)
# Puis :
git remote add origin https://github.com/VOTRE-USERNAME/votre-repo.git
git branch -M main
git push -u origin main

# 3. Déployer sur Railway (via interface web)
# - Allez sur railway.app
# - New Project → Deploy from GitHub
# - Sélectionnez votre repo
# - C'est tout !
```

**Votre application sera en ligne en moins de 5 minutes !** ⚡
