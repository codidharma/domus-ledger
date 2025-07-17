# 0002: Adopt Domain-Driven Design for Domus Ledger

**Status**: Accepted

**Date**: 2025-07-17

**Author**: Mandar Dharmadhikari

**Context**: Architectural Decision

## Context

The *Domus Ledger* project is a personal home finance management system that encompasses diverse responsibilities including:

- User and Role Management
- Income & Expense Tracking
- Budgeting
- Investment & Insurance Tracking
- Liability & EMI Management
- Timesheet & Household Activity Monitoring
- Cross-user Reporting & Aggregation

The problem space spans **complex business logic**, **multi-user coordination**, **interconnected aggregates**, and **domain-specific constraints** (e.g., budgeting rules, liability deduction flows, net worth reporting). This mandates a modeling approach that aligns software design with deep understanding of the business domain.


## Decision

We will adopt **Domain-Driven Design (DDD)** as the strategic architecture pattern for the Domus Ledger system.

## Rationale

| Reason | Justification |
|--------|---------------|
| **Tackles Business Complexity** | DDD focuses on modeling rich domain logic, which aligns with the complex finance rules, user-specific roles, and budget validation workflows. |
| **Modular Architecture** | Bounded contexts in DDD help us split the system into **well-defined modules** (e.g., Income Management, Investments, Reporting), enabling separation of concerns and high cohesion. |
| **Evolvability** | As household finances evolve (e.g., new investment instruments, changes in EMI policies), DDD’s decoupled architecture allows individual contexts to evolve independently. |
| **Ubiquitous Language** | Establishing a shared vocabulary between developers and stakeholders minimizes miscommunication and ensures requirements are faithfully represented in code. |
| **Event-Driven Collaboration** | Interactions between modules (e.g., Budget reacting to Income updates, Reporting consuming Investment/Expense updates) are handled cleanly via **domain events** and **event-driven messaging**, reducing coupling. |
| **Testability** | Domain models in DDD are easy to test in isolation (unit, architecture, integration tests), enabling high confidence in business correctness. |
| **Support for Modular Monolith** | DDD aligns well with a **modular monolith architecture**, our chosen style for better encapsulation with lower operational overhead. |
| **Alignment with Ports & Adapters** | DDD naturally supports hexagonal (ports & adapters) architecture, helping isolate UI, database, and external tools like OCR/Document parsers from core domain logic.

## Alternatives Considered

| Approach | Reason for Rejection |
|---------|-----------------------|
| Layered Architecture (3-tier) | Leads to anemic domain models, scattered business logic, and poor separation of concerns in complex scenarios. |
| Transaction Script | Fine for simple systems, but not scalable or maintainable for multiple interacting domains with rich state. |
| Microservices from Day 1 | Introduces unnecessary operational and deployment complexity. We're starting with a **modular monolith** and can extract services later if needed. |

## Consequences

- The project structure will be organized into **bounded contexts**, each with its own domain model, services, and interfaces.
- Events will be the primary mechanism for cross-context communication.
- Every domain module will have a clearly defined **Ubiquitous Language** captured in shared documentation.
- Developers will need to be familiar with DDD building blocks: aggregates, value objects, domain services, repositories, factories, etc.
- Project complexity will be front-loaded with careful modeling, but will pay off in long-term maintainability and clarity.

## Compliance

We will implement architecture tests to enforce the modularity for each domain.

## Related Decisions
