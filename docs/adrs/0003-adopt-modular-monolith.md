# 0002: Adopt Modular Monolith for Domus Ledger

**Status**: Accepted

**Date**: 2025-07-17

**Author**: Mandar Dharmadhikari

**Context**: Architectural Decision

## Context

Domus Ledger is a comprehensive desktop application aimed at managing personal and household finances. The application includes features such as user management, budgeting, income/expense tracking, investment and liability management, and time tracking for domestic activities. Given the rich domain model and complexity of the business rules, an architectural style that supports separation of concerns, maintainability, and scalability is critical.

There are several architectural styles available:
- Layered architecture
- Modular monolith
- Microservices
- Micro frontends (less relevant for desktop)
- Service-oriented architecture

## Decision

We will use a **Modular Monolith** architecture for Domus Ledger.


## Rationale

- **Domain Isolation**: Each domain module (e.g., Budgeting, Income, Investment, User Management) can be modeled as an independent unit with clear boundaries.
- **Developer Velocity**: Development is simpler and faster without network boundaries between modules.
- **Easier Refactoring**: Since all code lives in one process and one codebase, changes across modules can be done without deployment overhead.
- **Maintainability**: By using DDD principles within each module, we maintain a clear separation of concerns and reduce complexity.
- **Deployment Simplicity**: Since Domus Ledger is a desktop application, we package and deploy a single binary to the user.
- **Enables Future Evolution**: We can later extract modules into services (if needed) with clear boundaries already in place.

## Alternatives Considered

- **Layered Monolith**: Less flexible in separating concerns and does not promote bounded contexts as cleanly as modular monoliths.
- **Microservices**: Overhead not justified for single-user desktop application.

## Consequences

- Modules will be deployed together as a single binary.
- Modules will communicate via in-process mechanisms (e.g., services, events, commands).
- Shared kernel and cross-cutting concerns will be implemented via well-defined interfaces.


## Compliance

We will implement architecture tests to enforce the modularity for each domain.

## Related Decisions

0002: Adopt Domain-Driven Design for Domus Ledger