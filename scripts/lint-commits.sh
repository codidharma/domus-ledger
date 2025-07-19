#!/bin/bash

# Lint latest commit message against Conventional Commits format
# Example: feat(core): add new household relation support

set -e

COMMIT_MSG=$(git log -1 --pretty=%B)

REGEX="^(feat|fix|docs|style|refactor|perf|test|build|ci|chore|revert)(\([a-zA-Z0-9\-]+\))?: .{1,}$"

echo "Linting commit message:"
echo "$COMMIT_MSG"
if ! echo "$commit_msg" | grep -qE "$pattern"; then
    echo "Invalid commit message format!.Commit message must follow Conventional Commits format. Check https://www.conventionalcommits.org/en/v1.0.0/ for more details."
    echo ""
    echo "Commit message must follow Conventional Commits format:"
    echo "   <type>[optional scope]: <description>"
    echo ""
    echo "Valid types:"
    echo "   feat:     A new feature"
    echo "   fix:      A bug fix"
    echo "   docs:     Documentation changes"
    echo "   style:    Code style changes (formatting, etc.)"
    echo "   refactor: Code refactoring"
    echo "   perf:     Performance improvements"
    echo "   test:     Adding or updating tests"
    echo "   chore:    Maintenance tasks"
    echo "   build:    Build system changes"
    echo "   ci:       CI/CD changes"
    echo "   revert:   Revert previous commit"
    echo ""
    echo "Examples:"
    echo "   feat: add user authentication"
    echo "   fix(api): resolve null reference exception"
    echo "   docs: update README with setup instructions"
    echo ""
    exit 1
fi

echo "Commit message follows conventional format"