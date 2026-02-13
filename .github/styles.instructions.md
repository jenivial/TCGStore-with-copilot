---
applyTo: "TCGStore.Front/src/**/*.{css,html,jsx,tsx}"
---

# Frontend Style Guide (Agents)

This guide applies to all agents working on CSS and HTML updates in this repository. It is the agent-facing summary of the full guide in [docs/style-guide.md](../docs/style-guide.md).

## Applicability
- All agents must follow these instructions when touching frontend styles or markup.

## Applies To
- CSS files in TCGStore.Front.
- HTML and JSX/TSX markup in TCGStore.Front.

## Core Direction
- Theme: mythic, handcrafted, fantasy-inspired.
- Palette: earthy greens, parchment warmth, aged gold accents; avoid neon or purple-heavy palettes.
- Texture: subtle grain, engraved lines, stained paper, brushed metal.
- Lighting: soft glows, vignette edges, dappled light.

## CSS Rules
- Prefer CSS variables from `:root` in [TCGStore.Front/src/app/globals.css](../TCGStore.Front/src/app/globals.css).
- Use layered gradients and restrained ornamentation.
- Keep hover and focus-visible states visible and consistent.
- Respect `prefers-reduced-motion` for any animation or transitions.

## HTML Rules
- Keep markup semantic and accessible.
- Avoid color-only meaning; reinforce with text or icons.
- Use inclusive, gender-neutral language in copy.

## Accessibility
- Ensure readable contrast for body text and actions.
- Provide clear focus outlines on interactive elements.
- Keep font sizes readable and spacing generous.

## When Updating Styles
- Align with the component structure and naming already in use.
- If introducing new tokens, document them in [docs/style-guide.md](../docs/style-guide.md).
