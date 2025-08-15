# Thought Transfer Envelope (MCP-ready)

This repository emits a `wwwroot/thought.json` capturing the PMCRO state for transfer between agents (and MCP servers).

Example shape:

```json
{
  "kind": "thought",
  "version": 1,
  "timestamp": "2025-08-15T00:00:00Z",
  "intent": "Generate SaaS landing",
  "context": { "brand": { "name": "ACME" } },
  "products": {
    "app": { "title": "Your hero title", "subtitle": "Your subtitle" }
  },
  "provenance": {
    "pipeline": "Intent→Blueprint→Render",
    "agents": ["IntentAgent","ContextAgent","BlueprintAgent","RenderAgent"]
  }
}
```

Use this as a portable state capsule for planner→maker→checker→reflector cycles and MCP thought transfer.
