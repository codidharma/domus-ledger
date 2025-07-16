# scripts/setup-hooks.ps1

$gitHookFile = ".git/hooks/commit-msg"
$scriptPath = "scripts/commit-msg.ps1"

if (-not (Test-Path $scriptPath)) {
    Write-Host "❌ Could not find commit-msg.ps1 script." -ForegroundColor Red
    exit 1
}

$hookContent = @"
#!/bin/sh
pwsh -File "$scriptPath" "`$1"
"@

Set-Content -Path $gitHookFile -Value $hookContent -Encoding UTF8

# Ensure executable on Unix-like systems
try {
    bash -c "chmod +x .git/hooks/commit-msg"
} catch {
    Write-Host "Skipping chmod (non-Unix environment)"
}

Write-Host "Git commit-msg hook installed successfully!" -ForegroundColor Green
