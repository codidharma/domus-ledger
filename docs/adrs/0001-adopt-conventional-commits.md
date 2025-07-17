# 0001: Adopt Conventional Commits for Git Workflow

**Status**: Accepted

**Date**: 2025-07-17

**Context**: Source Control, Team Collaboration, Release Automation

**Author**: Mandar Dharmadhikari

---

## Decision

We will adopt the [Conventional Commits](https://www.conventionalcommits.org/) specification for all Git commit messages in this project. This will be enforced through a Git `commit-msg` hook using PowerShell.

---

## Context

As our project and team grow, we face challenges in:

- Understanding the **purpose of each commit** at a glance.
- Writing meaningful and **consistent commit messages** across developers.
- Automating **changelogs**, **semantic versioning**, and **CI/CD pipelines**.
- Improving code reviews by making **intent clearer** through commit types.

Conventional Commits is a lightweight convention that brings structure to commit messages by enforcing a consistent format like:

```
<type>(<optional-scope>): <description>
```
Example:
```
feat(ui): add dark mode toggle
fix(auth): handle invalid token edge case
```

---

## Consequences

### Positive Outcomes

- **Improved Clarity** in commit history (e.g., `feat:` vs. `fix:`).
- **Simplified Code Review**, especially in pull requests.
- Enables tools for **automated changelog generation**.
- Lays foundation for **semantic versioning**.
- Prevents bad or unclear commits from entering the repo.

### Trade-offs

- Developers must follow and learn the format.
- Requires setup (PowerShell-based hook) on each dev machine (automated via `setup-hooks.sh`).
- Slight upfront effort in training or documentation.

---

## Alternatives Considered

| Option | Pros | Cons |
|--------|------|------|
| No enforcement | Easiest | Inconsistent messages, difficult history |
| Manual review of commit messages | Enforces quality | Error-prone, inconsistent |
| Use commitlint (Node.js) | Popular tooling support | Adds NPM/Node dependency|

---

## Compliance

- We will enforce client side compliance using the `commit-msg` git hook
- We will use GitHub actions to implement server side compliance. The CI pipeline will fail if the commit message does not confirm to conventional commit

## References

- [Conventional Commits Specification](https://www.conventionalcommits.org/en/v1.0.0/)
- [Semantic Versioning](https://semver.org/)
- Related ADRs: _None yet_
