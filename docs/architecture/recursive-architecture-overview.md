# Autonomous AI Recursive Architecture Overview

## Core Concepts

- PMCRO Lifecycle:
  Plan → Make → Check → Reflect → Optimize cycles run continuously, evolving agent behaviors and system workflows.

- MCP Servers:
  Enable Thought Transfer by compressing and piping model context between agents and tools.

- Multi-Orchestrator Competition:
  Multiple orchestrators generate competing plans; a Meta-Referee adjudicates and synthesizes the best outcomes.

- LLM Federation Roundtable:
  Simulated multi-LLM group chats enable diverse perspectives and consensus-based reasoning.

- Local LLM Inference:
  Ollama-powered local LLMs (llama3.1:8b preferred) are first-class citizens, minimizing cloud dependency.

- Dynamic Plugin Lifecycle:
  Plugins and agents are generated at runtime via Roslyn; IL injection with Mono.Cecil is planned for advanced code weaving.

- Memory Persistence:
  PostgreSQL with pgvector stores embeddings for similarity search, enabling long-term reflection and learning.

- Hybrid API Exposure:
  Aspire AppHost exposes REST + gRPC APIs for orchestration control and observability.

## Development Priorities

1. Implement full pgvector-backed memory with embedding services.
2. Develop Meta-Referee agent with arbitration APIs.
3. Expand federation registry and consensus mechanisms.
4. Integrate Mono.Cecil IL injection for advanced plugin patching.
5. Build Aspire AppHost facade for enterprise-grade API exposure.

## Continuous Recursive Self-Improvement

- Every PMCRO cycle embeds outputs back into memory and updates priors.
- The recursive mastery prompt drives ongoing self-analysis, planning, and generation.
- Competing orchestrators and federated LLMs enable diverse ideation and robust convergence.
- Meta-Referee ensures coherence and quality across competing strategies.

---

This document is part of a living system; updates and refinements are performed automatically by the Autonomous AI Recursive Architect.
