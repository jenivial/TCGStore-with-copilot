# Documentation Agent (Planned)

## Purpose

This project will introduce a **custom documentation agent** to keep documentation current as the codebase and infrastructure evolve. The agent will be added in a future iteration and should integrate with the existing documentation set.

## Current Documentation Scope

The agent must respect and update the following documents as part of its baseline knowledge:

- [authentication.md](authentication.md) — AWS Cognito authentication design and integration details.
- [databases.md](databases.md) — AWS database architecture (DynamoDB, OpenSearch, RDS).

## Expected Responsibilities

- Keep technical documentation in sync with code and infrastructure changes.
- Maintain architectural consistency with the **Vertical Slice** approach.
- Reflect backend changes in **.NET** and frontend changes in **Next.js**.
- Track AWS infrastructure updates (e.g., new services, IAM changes, data stores).

## Integration Guidelines (Future)

When the custom documentation agent is added:

- It should update docs incrementally, not overwrite them wholesale.
- It should preserve existing sections and add new ones only when needed.
- It should link to relevant feature slices and infrastructure definitions.
- It should run as part of the developer workflow (e.g., pre-merge or release checks).

## Status

Planned — to be implemented in a future iteration.
