## Strange Loop Ecosystem

This system implements recursive strange loops where optimized outputs become the next inputs. Core roles:

- Orchestrators: Competing PMCRO loops proposing and executing plans
- Referee: Meta-agent governing fairness, selecting winners, or forcing consensus
- Federation: Multiple personas collaborating/competing to improve solutions
- Thought Transfer: MCP-based compact context packets refined each cycle

Key properties:
- Event-driven orchestration with Process Framework YAML
- Self-reference: outputs feed future inputs
- Governance: interventions logged and auditable

Concrete pieces in this repo:
- Referee agent: `src/ProjectName.AI/Agents/RefereeAgent.cs`
- SK PMCRO steps: `src/ProjectName.AI/Plugins/PMCROSteps.cs`
- MCP bridge stub: `ThoughtTransferBridge` in `PMCROSteps.cs`


