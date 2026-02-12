# Copilot Instructions

## Architecture
- Use **Vertical Slice Architecture**: organize by feature/slice, not layers.
- Each slice owns its API, domain, handlers, and persistence concerns.

## Backend
- Backend is **.NET**.
- Prefer minimal APIs or feature-based controllers per slice.
- Keep slice boundaries clear and avoid cross-slice coupling.

## Frontend
- Frontend is **Next.js**.
- Align UI and API usage with backend slices.

## Infrastructure
- Use **AWS services** for infrastructure (e.g., auth, data, storage, compute, search).
- Infrastructure definitions should be IaC-friendly.

## Documentation
- Documentation must be kept up to date.
- A custom documentation agent will be introduced later; plan changes so it can integrate cleanly.

## General
- Favor consistency with existing slices and patterns.
- Keep examples and suggestions aligned with this stack.
