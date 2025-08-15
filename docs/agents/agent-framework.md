# Semantic Kernel Agent Framework

This system uses the Semantic Kernel (SK) Agent Framework to realize PMCRO loops with thought transfer and self-referential evolution. This page summarizes the key primitives and how we apply them.

## Agent primitives

- ChatCompletionAgent: Core intelligent actor with instructions, tools (plugins), and auto function calling.
- Agent Thread (ChatHistoryAgentThread): Conversation context that persists messages, function calls, and intermediate artifacts across invocations.
- Agent Group Chat: Coordinated set of agents that take turns (round-robin or policy-driven) with termination strategies and filters.
- Function Choice Behavior: Auto or constrained function selection to govern tool invocation.
- Filters and Termination: Interceptors for control and guardrails; limit iterations or stop on conditions.

## How we leverage them

- PMCRO roles as agents: Planner, Maker, Checker, Reflector, Optimizer realized as specialized ChatCompletionAgents with “I”-centric instructions.
- Threads as working memory: Each phase uses a thread to accumulate context and intermediate results; threads can be transferred or merged.
- Group chat for multi-intelligence: Run PMCRO roles in a group with a policy (e.g., Planner → Maker → Checker → Reflector → Optimizer) and stop rules.
- Plugin chaining: Each “thought” maps to a function call. Approaching a lock, agents call the self-referential plugin to add the missing capability, then continue.
- Thought transfer via MCP: Compact context packets move between agents/threads using MCP tools (compress, receive), enabling efficient recursion.

## Minimal configuration pattern

```csharp
var kernel = Kernel.CreateBuilder()
    // Add model + plugins here
    .Build();

var planner = new ChatCompletionAgent
{
    Name = "Planner",
    Instructions = "I plan by decomposing behavior intents into executable components.",
    Kernel = kernel,
    Arguments = new(new PromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
};

var thread = new ChatHistoryAgentThread();
await planner.InvokeAsync(new ChatMessageContent(AuthorRole.User, intent), thread);
```

## Termination strategies

- Max turns/iterations in group chat
- Confidence or quality threshold (e.g., validation score)
- External event (referee decision, session completion)

## Best practices

- Use “I”-form instructions to embody internal will and self-direction.
- Keep plugins small, typed with [KernelFunction] and [Description] for clarity and toolability.
- Detect lock points (capability gaps) and route to the self-referential plugin to generate new capabilities.
- Record emergent patterns and transfer compact context using MCP between agents and threads.
