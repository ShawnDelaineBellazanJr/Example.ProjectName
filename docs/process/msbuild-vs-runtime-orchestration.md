# MSBuild Task vs Runtime Orchestration

This note clarifies how the generator integrates with MSBuild and the application, and whether to run the SK Process Framework inside a build task.

## Data flow
- Template/new-project: capture name/version (+ optionally intent/context) and scaffold the solution.
- Build-time (MSBuild Task): the task runs once per build, generates artifacts (e.g., wwwroot/index.generated.html, wwwroot/app.json).
- App runtime: the web host serves generated files; optionally a runtime orchestrator can evolve content further.

## Is an MSBuild task “a DLL I can trigger from the app”?
- MSBuild tasks are .NET assemblies loaded by MSBuild with special dependencies on the build engine types.
- You can reference the task DLL from the app, but it’s not recommended:
  - It couples your runtime to MSBuild APIs and binlayout.
  - CI agents and local dev may differ.
- Preferred: put generation logic in a separate library the task and the app both call.

## Running Process Framework inside the MSBuild task
Powerful, but use carefully.

Pros:
- "Press Create → Build → Instant output" experience.
- Deterministic scaffolding of initial assets.

Cons/Risks:
- Non-deterministic LLM calls in build break reproducibility.
- Slow builds and CI timeouts.
- Harder failure modes (network, rate limits) during compile.
- Risk of recursion if the task triggers builds indirectly.

Guideline:
- Use build-time only for quick, idempotent generation of static assets.
- Run longer SK processes at runtime or via a separate CLI/job.

## Recommended architecture
- Core generator library (e.g., ProjectName.Generator):
  - API: `Task<GenerationResult> GenerateAsync(string intent, string? contextJson, string outDir)`
  - Output: HTML, app.json (+ logs/metrics)
- Thin drivers:
  - MSBuild Task: calls the library (no shell-out), guarded by `EnableProcessGenerator`.
  - CLI (`ProjectName.Process`): dev/manual runs and CI jobs.
  - Optional IHostedService in Web: gated by config; runs small updates at startup or on triggers.
- SK Process Framework:
  - Express Intent → Blueprint → Render as SK steps; provide a `.process.yaml` for preview/debug.
  - Drivers (CLI/runtime) invoke the process; MSBuild uses the library for fast/deterministic paths.

## Practical notes
- Make build input/output incremental (MSBuild Inputs/Outputs) so generation only runs when intent/context changes.
- Set short timeouts/retries; emit a clear message if the generator is skipped.
- Store intent/context in source (`/process/intent.json`) or as properties to ensure reproducible builds.

### Optional feedback loop (lock → promote → re-intent)
- The generator can promote a locked thought into a refined intent and feed it into the next iteration.
- Enable via:
  - CLI: `--feedback`
  - MSBuild: `-p:ProcessFeedback=true`
- See `docs/process/feedback-loop.md` for details and examples.

## Next steps
- Extract generator core into `src/ProjectName.Generator` and refactor the task to call it.
- Add `landing-generator.process.yaml` mirroring the samples in `/samples/sk-process-framework`.
- Add template prompts for `intent`/`context` and pass to first build.
