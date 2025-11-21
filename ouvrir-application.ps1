# Script pour ouvrir automatiquement l'application
Write-Host "Ouverture de l'application dans le navigateur..." -ForegroundColor Cyan

# Attendre que l'application soit prête
Start-Sleep -Seconds 5

# Ouvrir la page d'accueil
Start-Process "http://localhost:5008"

# Attendre un peu
Start-Sleep -Seconds 2

# Ouvrir l'API dans un nouvel onglet
Start-Process "http://localhost:5008/api/StatsApi"

Write-Host "`n✅ Application ouverte dans le navigateur!" -ForegroundColor Green
Write-Host "`nURLs disponibles:" -ForegroundColor Cyan
Write-Host "  - Page d'accueil: http://localhost:5008" -ForegroundColor Yellow
Write-Host "  - API Stats: http://localhost:5008/api/StatsApi" -ForegroundColor Yellow
Write-Host "  - API Departements: http://localhost:5008/api/DepartementsApi" -ForegroundColor Yellow
Write-Host "  - API Salaries: http://localhost:5008/api/SalariesApi" -ForegroundColor Yellow
Write-Host "  - API Projets: http://localhost:5008/api/ProjetsApi" -ForegroundColor Yellow

