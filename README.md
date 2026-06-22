# DevLearn — Online Learning Platform

A web-based educational platform for developers, built with **ASP.NET Core MVC** following **Modular Monolith** architecture and **Domain-Driven Design (DDD)** principles.

## Architecture

The project is structured as a Modular Monolith where each business domain is an independent module with its own layers, communicating through a Facade interface and an internal EventBus.

```
src/
├── EndPoints/
│   └── DevLearn.Web          # ASP.NET Core MVC — Entry Point
│
├── Modules/
│   ├── Core                  # Courses, lessons, categories
│   │   ├── Domain
│   │   ├── Application
│   │   ├── Infrastructure
│   │   ├── Query
│   │   ├── Facade
│   │   └── Config
│   ├── User                  # Authentication & user management
│   ├── Blog                  # Articles & educational content
│   ├── Comment               # User comments
│   ├── Ticket                # Support ticketing
│   └── Transaction           # Payments & purchase history
│
└── Common/
    ├── Common.Domain
    ├── Common.Application
    ├── Common.Infrastructure
    ├── Common.Query
    └── Common.EventBus
```

## Key Design Patterns

- **Modular Monolith** — independent modules with clear boundaries
- **DDD** — domain modeling with Entities, Value Objects, and Aggregates
- **CQRS** — separated read and write responsibilities
- **Facade Pattern** — clean inter-module communication
- **EventBus** — loosely coupled events between modules

## Tech Stack

| | |
|---|---|
| Backend | ASP.NET Core MVC |
| Language | C# |
| Frontend | HTML · CSS · SCSS · JavaScript |
| Architecture | Modular Monolith + DDD + CQRS |
