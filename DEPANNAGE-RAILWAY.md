# 🔧 Guide de Dépannage Railway

## ❓ Problème : "Je ne vois rien" sur Railway

### ✅ Vérifications à faire :

#### 1. **Vérifier que le projet est bien connecté**
- Allez sur [railway.app](https://railway.app)
- Cliquez sur votre projet
- Vérifiez que vous voyez un service avec le nom de votre repository

#### 2. **Vérifier les logs**
- Dans Railway, cliquez sur votre service
- Allez dans l'onglet **"Logs"** ou **"Deployments"**
- Regardez les logs pour voir s'il y a des erreurs

#### 3. **Vérifier le statut du déploiement**
- Dans Railway, vous devriez voir :
  - **Building** (en construction) - orange
  - **Deploying** (en déploiement) - bleu
  - **Active** (actif) - vert ✅
  - **Failed** (échec) - rouge ❌

#### 4. **Si le déploiement a échoué**
Regardez les logs pour voir l'erreur. Erreurs communes :

**Erreur : "Could not find project"**
- Solution : Vérifiez que `mac.csproj` est bien à la racine du projet

**Erreur : "Port not found"**
- Solution : Railway devrait configurer automatiquement le port via la variable `$PORT`

**Erreur : "Database migration failed"**
- Solution : Les migrations sont appliquées automatiquement, mais vérifiez les logs

#### 5. **Forcer un nouveau déploiement**
- Dans Railway, allez dans **"Settings"** de votre service
- Cliquez sur **"Redeploy"** ou **"Deploy"**
- Ou poussez un nouveau commit sur GitHub :
  ```bash
  git commit --allow-empty -m "Trigger redeploy"
  git push origin main
  ```

#### 6. **Vérifier l'URL publique**
- Dans Railway, allez dans **"Settings"** de votre service
- Cherchez **"Generate Domain"** ou **"Custom Domain"**
- Cliquez pour générer une URL publique
- L'URL sera du type : `https://votre-projet.up.railway.app`

## 🚨 Solutions Rapides

### Solution 1 : Vérifier la configuration Railway
Assurez-vous que `railway.json` est bien présent à la racine du projet.

### Solution 2 : Vérifier que Railway a accès à GitHub
- Allez dans Railway → Settings → GitHub
- Vérifiez que votre repository `kalil-cyber/projet-entreprise` est bien connecté

### Solution 3 : Redémarrer le service
- Dans Railway, cliquez sur votre service
- Allez dans **"Settings"**
- Cliquez sur **"Restart"**

### Solution 4 : Vérifier les variables d'environnement
Railway devrait automatiquement configurer :
- `PORT` (automatique)
- `ASPNETCORE_ENVIRONMENT` (peut être défini sur "Production")

## 📋 Checklist de Vérification

- [ ] Le repository GitHub est bien connecté à Railway
- [ ] Le service est visible dans Railway
- [ ] Les logs montrent une activité (build ou erreur)
- [ ] L'URL publique est générée
- [ ] Le statut est "Active" (vert)

## 🆘 Si rien ne fonctionne

1. **Vérifiez que vous êtes bien connecté à Railway**
   - Allez sur [railway.app](https://railway.app)
   - Vérifiez que vous êtes connecté avec votre compte GitHub

2. **Recréez le projet**
   - Supprimez le service actuel dans Railway
   - Créez un nouveau projet
   - Sélectionnez "Deploy from GitHub repo"
   - Choisissez `kalil-cyber/projet-entreprise`

3. **Vérifiez les logs détaillés**
   - Dans Railway, ouvrez les logs complets
   - Copiez les erreurs et cherchez-les sur Google

## 💡 Alternative : Utiliser Render.com

Si Railway ne fonctionne pas, essayez Render.com :
1. Allez sur [render.com](https://render.com)
2. Créez un compte
3. "New" → "Web Service"
4. Connectez GitHub et sélectionnez `projet-entreprise`
5. Render détectera automatiquement .NET et déploiera

---

**Besoin d'aide ?** Partagez les logs d'erreur que vous voyez dans Railway !

