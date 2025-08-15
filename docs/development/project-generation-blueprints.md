# Project generation blueprints

This defines how we describe and generate projects, components, and libraries.

- ProjectBlueprint: app kind, target framework, UI stack, feeds, libraries, modules/components.
- UiBlueprint: page content model decoupled from UI frameworks.

## Telerik bleeding-edge conventions
- Use `TelerikRootComponent` and Kendo theme utilities.
- Prefer semantic components with consistent slots/parts.
- Icons by name, resolved in view layer (`Telerik.SvgIcons`).
- Dark-mode aware palettes; respect OS prefers-color-scheme.

## Generation
- Feeds: set up NuGet sources including private Telerik feed (read secrets from env vars).
- Libraries: add package refs per source.
- Modules/components: scaffold Razor/pages; swap implementation based on `ui`.
- Content: inject from `UiBlueprint` JSON or Prompty-generated tokens.
