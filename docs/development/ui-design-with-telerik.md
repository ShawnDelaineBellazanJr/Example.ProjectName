# UI Domain and Design Conventions (Telerik)

This document defines a portable UI domain and conventions for building bleeding-edge UIs using Telerik UI for Blazor while keeping domain models decoupled from UI frameworks.

## Domain principles
- Keep models UI-agnostic. Do not depend on Telerik types (e.g., ISvgIcon) in models; use strings or enums.
- ViewModels map domain to UI components.
- Content is externalizable as JSON (see `UiBlueprint.schema.json`).

## UI blueprint
Use `UiBlueprint` to describe landing pages and similar experiences: branding, navigation, hero, features, testimonials, pricing, partners, newsletter.

## Telerik conventions
- Use TelerikRootComponent at the app root when enabled.
- Prefer utility classes from Kendo theme for layout and spacing.
- Components: AppBar, Menu, Button, SvgIcon, Avatar, Rating, TextBox.
- Icons: refer to icons by name string; resolve to `Telerik.SvgIcons` in the view layer only.

## Migration paths
- Static host → Razor + OSS → Telerik-enabled by adding the private feed and package.
- Swap `<Telerik*>` components with semantics while keeping ViewModel stable.
