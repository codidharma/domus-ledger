#!/bin/bash

echo "Installing Git hook for commit-msg..."

HOOK_DIR=".git/hooks"
HOOK_FILE="$HOOK_DIR/commit-msg"

if [ ! -d "$HOOK_DIR" ]; then
  echo "Not a Git repository. Run from root."
  exit 1
fi

cp scripts/commit-msg "$HOOK_FILE"
chmod +x "$HOOK_FILE"

echo "Hook installed at $HOOK_FILE"
