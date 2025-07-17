# Git Commit Hook Setup (Conventional Commits Enforcement)

This project uses **Conventional Commits** to ensure clean, structured commit messages that help with versioning, changelog generation, and better team collaboration.

**Commit format example:**
 ```
 feat(ui): add dark mode toggle
 fix(auth): handle token expiration error
 ```


## What You Need

- Git Bash


## Setup Instructions

Run this command from the root of the repository:

```bash
bash scripts/setup-hooks.sh
```

This will:

- Create a `commit-msg` Git hook in `.git/hooks/`
- Automatically block any commit message that does **not** follow the Conventional Commit format


## Commit Message Rules (Conventional Commits)

**Valid types** include:

- `feat` – New feature
- `fix` – Bug fix
- `docs` – Documentation-only changes
- `style` – Code formatting, missing semicolons, etc.
- `refactor` – Code changes that neither fix a bug nor add a feature
- `test` – Adding missing tests
- `chore` – Maintenance changes
- `build` – Changes that affect the build system or dependencies
- `ci` – Changes to CI configuration
- `revert` – Reverts a previous commit

**Examples**:

```bash
feat: implement salary tracking feature

fix(expense): correct total calculation logic

chore: clean up old log files
```

---

## Testing

Try committing a file:

```bash
git commit -m "update readme"
```

You should see an error like:

```
Invalid commit message format!.Commit message must follow Conventional Commits format. Check https://www.conventionalcommits.org/en/v1.0.0/ for more details.

```

Try again with a valid format:

```bash
git commit -m "docs: update readme with setup instructions"
```
This will result in a successful commit.


## FAQ

### What if the hook doesn’t run?

- Ensure Git Bash is installed and available in your system PATH.
- Ensure the hook file is executable (especially on macOS/Linux):
  Run: `chmod +x .git/hooks/commit-msg`
- Re-run: `bash scripts/setup-hooks.sh` after switching branches or recloning the repo.

### Can I bypass the commit check?

Yes, though not recommended. Use the `--no-verify` flag:

```bash
git commit -m "some message" --no-verify
```