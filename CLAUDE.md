# CLAUDE.md

## Project Overview

optimalDB is a database optimization and management tool for SQL Server. It loads connection strings, provides access to databases and their objects, and generates C# code (classes, records) from database schemas.

## Tech Stack

- .NET 10.0 (C#)
- Windows Forms (UI)
- SQL Server (target databases)
- NUnit (testing)

## Repository Structure

- `Source/optimalDb/` — Solution root containing all projects
  - `optimalDb.WinForms/` — Windows Forms UI application
  - `optimalDb.Domain/` — Domain logic
  - `optimalDb.Contracts/` — Interfaces and contracts
  - `optimalDb.Interactors/` — Business logic / use cases
  - `optimalDb.Interactors.Tests/` — Tests for interactors
  - `optimalDb.Persistence/` — Data access layer
  - `optimalDb.Console/` — Console application

## Build Commands

```bash
# Restore dependencies
dotnet restore Source/optimalDb/optimalDb.sln

# Build
dotnet build Source/optimalDb/optimalDb.sln

# Run tests
dotnet test Source/optimalDb/optimalDb.sln

# Build release
dotnet build Source/optimalDb/optimalDb.sln --configuration Release
```

## Conventions

- Block-scoped namespaces (do NOT convert to file-scoped)
- Nullable reference types enabled
- Warnings exist (mainly nullable in WinForms) — TreatWarningsAsErrors is NOT enabled
- NUnit for unit tests with Arrange-Act-Assert pattern
- Solution follows Clean Architecture: Contracts -> Domain -> Interactors -> Persistence -> UI
