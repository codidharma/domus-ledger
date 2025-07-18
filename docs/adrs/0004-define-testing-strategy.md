# 0004: Define Testing Strategy

**Status**: Accepted

**Date**: 2025-07-17

**Context**: Team Collaboration, Development, Testing, Release Automation

**Author**: Mandar Dharmadhikari


## Context
As the Domus Ledger project is a critical financial application, maintaining a high level of software quality, reliability, and maintainability is essential. A well-defined testing strategy must be adopted to cover different layers of the system effectively.

## Decision

We will adopt an **Inside-Out Testing Strategy**, we will start by building the domain through Test Driven Development Approach and then move out to implement the integrations and presentation layers.

Our testing layers will include:

1. **Acceptance Tests (End-to-End)** – (Future scope) Driven by business capabilities, using tools like SpecFlow or BDD-style frameworks.
2. **Integration Tests** – Validate the integration between modules, databases, and external services.
3. **Unit Tests** – Fast, isolated tests for small units of behavior (methods/classes).
4. **Architecture Tests** – Ensure adherence to modular monolith principles (layering, dependency rules, boundaries).

### Testing Framework

We will standardize all our tests using **xUnit** for the following reasons:

- **Modern & Actively Maintained**: xUnit is a modern test framework with ongoing support and improvements.
- **Strong .NET Ecosystem Support**: Integrates seamlessly with `.NET 9` and tools like Visual Studio, JetBrains Rider, and CI/CD systems.
- **Clean Architecture Alignment**: Encourages minimal test fixture setup and constructor injection.
- **Extensible**: Supports shared contexts, custom test collections, fixtures, and data-driven testing.

### Layered Testing Responsibility

| Layer               | Tool      | Purpose                                                  |
|---------------------|-----------|-----------------------------------------------------------|
| Unit Tests          | xUnit     | Test single methods or classes in isolation              |
| Integration Tests   | xUnit     | Test database, APIs, and service boundaries               |
| Architecture Tests  | NetArchTest | Enforce architectural constraints (hexagonal, layering etc.) |

### Additional Notes

- Tests will follow the Arrange-Act-Assert (AAA) pattern.
- Integration tests will use TestContainers/Docker for replicating services and databases.
- Common base classes or fixtures will be placed in a shared test utility library
- Code coverage targets will be enforced using Coverlet or similar tooling.
- All CI/CD workflows will run tests in GitHub Actions on push/pull requests.

## Consequences

- Encourages test driven development
- Ensures confidence in making changes without regressions
- Consistent testing approach across modules and teams
- Requires effort in test scaffolding and containerization

## Alternatives Considered

- MSTest: too legacy, limited extensibility
- NUnit: good support, but less idiomatic for modern .NET workflows
- Using multiple test frameworks: adds maintenance overhead and inconsistency

## References

- [xUnit documentation](https://xunit.net)
- [Outside-in testing strategy](https://martinfowler.com/bliki/OutsideInTDD.html)
- [NetArchTest](https://github.com/BenMorris/NetArchTest)

