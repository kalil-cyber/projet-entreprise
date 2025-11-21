# Script de test des API
Write-Host "=== Test des API ===" -ForegroundColor Cyan
Write-Host ""

# Attendre que l'application soit prête
Write-Host "Attente du démarrage de l'application..." -ForegroundColor Yellow
Start-Sleep -Seconds 3

# Test 1: Statistiques
Write-Host "1. Test /api/StatsApi" -ForegroundColor Green
try {
    $response = Invoke-WebRequest -Uri "http://localhost:5008/api/StatsApi" -UseBasicParsing
    Write-Host "   Status: $($response.StatusCode)" -ForegroundColor Green
    $json = $response.Content | ConvertFrom-Json
    Write-Host "   Total Departements: $($json.TotalDepartements)"
    Write-Host "   Total Salaries: $($json.TotalSalaries)"
    Write-Host "   Total Projets: $($json.TotalProjets)"
    Write-Host "   SUCCESS!" -ForegroundColor Green
} catch {
    Write-Host "   ERREUR: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""

# Test 2: Départements
Write-Host "2. Test /api/DepartementsApi" -ForegroundColor Green
try {
    $response = Invoke-WebRequest -Uri "http://localhost:5008/api/DepartementsApi" -UseBasicParsing
    Write-Host "   Status: $($response.StatusCode)" -ForegroundColor Green
    $json = $response.Content | ConvertFrom-Json
    Write-Host "   Nombre de departements: $($json.Count)"
    Write-Host "   SUCCESS!" -ForegroundColor Green
} catch {
    Write-Host "   ERREUR: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""

# Test 3: Salariés
Write-Host "3. Test /api/SalariesApi" -ForegroundColor Green
try {
    $response = Invoke-WebRequest -Uri "http://localhost:5008/api/SalariesApi" -UseBasicParsing
    Write-Host "   Status: $($response.StatusCode)" -ForegroundColor Green
    $json = $response.Content | ConvertFrom-Json
    Write-Host "   Nombre de salaries: $($json.Count)"
    Write-Host "   SUCCESS!" -ForegroundColor Green
} catch {
    Write-Host "   ERREUR: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""

# Test 4: Projets
Write-Host "4. Test /api/ProjetsApi" -ForegroundColor Green
try {
    $response = Invoke-WebRequest -Uri "http://localhost:5008/api/ProjetsApi" -UseBasicParsing
    Write-Host "   Status: $($response.StatusCode)" -ForegroundColor Green
    $json = $response.Content | ConvertFrom-Json
    Write-Host "   Nombre de projets: $($json.Count)"
    Write-Host "   SUCCESS!" -ForegroundColor Green
} catch {
    Write-Host "   ERREUR: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""
Write-Host "=== Fin des tests ===" -ForegroundColor Cyan

