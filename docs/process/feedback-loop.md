# Intent Feedback Loop (Lock → Promote → Re-Intent)

This repo supports an optional feedback loop that promotes a locked chain-of-thought into a refined intent and feeds it back into the next iteration.

Key pieces:
- Thought envelope includes `iterations { current, total }`, `status.locked`, and `promotedIntent`.
- `PromotionAgent` injects `promotedIntent` (and `promotionReason`).
- `--feedback` flag enables feeding `promotedIntent` as the next iteration's intent.
- MSBuild property `ProcessFeedback` forwards to `--feedback` during the web build.

CLI:

```sh
dotnet run --project src/ProjectName.Process -- --intent "Create a slick SaaS landing" --iterations 2 --feedback
```

Build (web project):

```sh
dotnet build -p:EnableProcessGenerator=true -p:ProcessFeedback=true
```

Outputs: `wwwroot/thought.json` shows lock state and `promotedIntent`. With feedback on, the next iteration uses it as intent.
