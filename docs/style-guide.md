# Style Guide

This guide defines the visual language for TCGStore Front. The goal is a mythic, handcrafted, fantasy-inspired look with earthy greens, parchment warmth, and subtle texture cues.

## Design Principles
- Atmosphere: adventurous, grounded, and warm; avoid cold or neon palettes.
- Clarity: keep layouts readable with generous spacing and strong contrast.
- Restraint: use ornamental details sparingly and consistently.

## Color Palette
Use these tokens from `:root` in [TCGStore.Front/src/app/globals.css](../TCGStore.Front/src/app/globals.css).

- Ink: `--ink` (#0c130f) for primary text.
- Muted: `--muted` (#4f5e54) for secondary text.
- Canvas: `--canvas` (#e6eedf) for page backdrops.
- Surface: `--surface` (#f4f7ef) for panels and cards.
- Accent: `--accent` (#3d7f4a) and `--accent-dark` (#1f4b2c) for primary actions.
- Accent glow: `--accent-glow` (#a8cf85) for highlights and focus states.
- Danger: `--danger` (#7a2b1c) and `--danger-soft` (#f2dfd7) for error callouts.
- Line: `--line` for subtle dividers.
- Shadows: `--shadow` for default elevation and `--shadow-strong` for hover lifts.

## Typography
- Display: `--font-display` (Fraunces) for headings.
- Body: `--font-body` (Space Grotesk) for paragraphs and UI text.
- Headings should feel carved and elegant; keep weights moderate.

## Layout and Spacing
- Use wide, breathable spacing with soft edges; avoid tight, cramped grids.
- Keep `main` content centered with a max-width for large displays.
- Rounded corners should be consistent (`--radius`).

## Surfaces and Texture
- Prefer layered gradients and gentle vignettes over flat fills.
- Use subtle grain or engraved-line effects via low-opacity gradients.
- Avoid heavy gloss or plastic-like sheen.

## Components
### Buttons
- Primary buttons use green gradients and light text.
- Ghost buttons use transparent backgrounds with light borders.
- Always include clear hover and focus-visible states.

### Cards
- Card tiles use a parchment-leaning surface with a moss glow.
- Maintain soft shadows and slightly elevated hover states.
- Use uppercase metadata to suggest a catalog-like feel.

### Callouts
- Use warm parchment backgrounds with a green border.
- Error callouts shift toward muted, earthen reds.

## Accessibility and Inclusion
- Provide high-contrast text over backgrounds.
- Use focus-visible outlines for keyboard navigation.
- Avoid color-only meaning; reinforce with text or iconography.
- Keep animations subtle and respect reduced-motion preferences.
- Use inclusive, gender-neutral language in UI copy.

## Do/Don’t
- Do: Use earthy greens, parchment, and aged gold sparingly.
- Do: Keep typography expressive but readable.
- Don’t: Introduce neon, sci-fi, or purple-heavy palettes.
- Don’t: Overuse decorative borders or heavy textures.
