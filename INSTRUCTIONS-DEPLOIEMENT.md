# 🚀 Instructions de Déploiement - kalil-cyber

## ✅ Étape 1 : Créer le dépôt GitHub

1. Allez sur [github.com](https://github.com) et connectez-vous avec votre compte **kalil-cyber**
2. Cliquez sur le bouton **"+"** en haut à droite → **"New repository"**
3. Nommez votre dépôt (ex: `gestion-entreprise` ou `mac`)
4. **Ne cochez PAS** "Initialize with README" (le dépôt est déjà initialisé)
5. Cliquez sur **"Create repository"**

## ✅ Étape 2 : Connecter votre dépôt local à GitHub

**Remplacez `NOM-DU-REPO` par le nom que vous avez choisi :**

```bash
git remote add origin https://github.com/kalil-cyber/NOM-DU-REPO.git
git push -u origin main
```

**Exemple si votre repo s'appelle `gestion-entreprise` :**
```bash
git remote add origin https://github.com/kalil-cyber/gestion-entreprise.git
git push -u origin main
```

## ✅ Étape 3 : Déployer sur Railway (RECOMMANDÉ)

1. Allez sur [railway.app](https://railway.app)
2. Cliquez sur **"Start a New Project"**
3. Choisissez **"Deploy from GitHub repo"**
4. Autorisez Railway à accéder à votre compte GitHub
5. Sélectionnez votre repository (`NOM-DU-REPO`)
6. Railway détecte automatiquement .NET 10.0 et déploie !
7. Votre application sera accessible sur : `https://NOM-DU-PROJET.up.railway.app`

**C'est tout ! En 5 minutes vous avez un lien de déploiement !** 🎉

## ✅ Étape 4 : Déployer sur Render (Alternative)

1. Allez sur [render.com](https://render.com)
2. Créez un compte gratuit
3. Cliquez sur **"New"** → **"Web Service"**
4. Connectez votre compte GitHub
5. Sélectionnez votre repository
6. Render détecte automatiquement le projet .NET 10.0
7. Cliquez sur **"Create Web Service"**
8. Votre URL : `https://NOM-DU-PROJET.onrender.com`

**Note :** Render peut être un peu lent au démarrage (cold start), mais c'est gratuit !

---

## 📋 Commandes Git Rapides

Si vous devez faire des modifications après le déploiement :

```bash
# Faire des modifications dans votre code...

# Ajouter les changements
git add .

# Créer un commit
git commit -m "Description des modifications"

# Pousser vers GitHub (le déploiement se mettra à jour automatiquement)
git push origin main
```

---

## 🎯 Pour votre Présentation

**Donnez ce lien à votre professeur :**
- Railway : `https://[nom-projet].up.railway.app`
- Render : `https://[nom-projet].onrender.com`

**Exemple de présentation :**
> "J'ai développé une application de gestion d'entreprise avec ASP.NET Core 10.0 MVC. 
> L'application est déployée et accessible en ligne à l'adresse : 
> [votre-lien]"

---

## ⚠️ Notes Importantes

- **Railway** : Gratuit avec 500 heures/mois (plus que suffisant pour un projet scolaire)
- **Render** : Gratuit mais peut être lent au premier démarrage
- Les deux sont parfaits pour des projets scolaires !
- La base de données SQLite sera créée automatiquement lors du premier lancement
- **.NET 10.0** est automatiquement détecté par les deux plateformes

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

## ✅ Checklist de Déploiement

- [x] Fichier .gitignore créé
- [x] Git initialisé et commit créé
- [x] Configuration Railway corrigée
- [ ] Dépôt GitHub créé
- [ ] Code poussé sur GitHub
- [ ] Compte créé sur Railway ou Render
- [ ] Projet déployé
- [ ] Lien testé et fonctionnel
- [ ] Prêt pour la présentation ! 🎉

