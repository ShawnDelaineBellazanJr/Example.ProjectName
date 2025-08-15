# Solution Orchestration Graph

```mermaid
flowchart TB
    subgraph AppHost [Aspire AppHost]
        APH[ProjectName.AppHost]
    end

    subgraph Infra [Infrastructure]
        DB[(PostgreSQL appdb)]
        MIG[EF Auto-Migration (Dev)]
        SK[Semantic Kernel + Ollama]
    end

    subgraph API [REST API]
        ORCHAPI[ProjectName.OrchestrationApi]
    end

    subgraph Orchestrator [gRPC]
        ORCHSVC[ProjectName.OrchestratorService]
    end

    subgraph Services [PMCRO Specialists]
        PLAN[PlannerService]
        MAKE[MakerService]
        CHECK[CheckerService]
        REFL[ReflectorService]
    end

    APH -->|ref & env: USE_INMEMORY_DB, OLLAMA_*| ORCHAPI
    APH -->|ref & env| ORCHSVC
    APH -->|ref & env| PLAN
    APH -->|ref & env| MAKE
    APH -->|ref & env| CHECK
    APH -->|ref & env| REFL
    APH -->|AddDatabase(appdb)| DB

    ORCHAPI -->|REST /api/orchestrator/*| ORCHSVC
    ORCHAPI -->|gRPC clients| PLAN & MAKE & CHECK & REFL
    ORCHAPI -.->|/health/orchestrator| ORCHSVC

    ORCHSVC -->|Background Loop| DB
    ORCHSVC -->|ThoughtTransfer (SK/Ollama, MCP fallback)| SK
    ORCHSVC -.->|future gRPC| PLAN & MAKE & CHECK & REFL

    MIG --> DB
```
