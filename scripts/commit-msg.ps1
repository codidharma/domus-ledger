# scripts/commit-msg.ps1

param (
    [string]$commitMsgFile
)

$commitMessage = Get-Content $commitMsgFile -Raw
$regex = '^(feat|fix|docs|style|refactor|perf|test|build|ci|chore|revert)(\([^)]+\))?: .+'

if ($commitMessage -notmatch $regex) {
    Write-Host "Commit message does NOT follow Conventional Commit format." -ForegroundColor Red
    Write-Host "Expected: <type>(optional scope): <description>" -ForegroundColor Yellow
    Write-Host "Examples:"
    Write-Host "  - feat: add login button"
    Write-Host "  - fix(auth): handle token expiration"
    exit 1
}

Write-Host "Commit message follows Conventional Commit format." -ForegroundColor Green
