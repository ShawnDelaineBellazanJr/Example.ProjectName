# Create from Template

## Install the template
```sh
dotnet new install .
```

## Create a project
```sh
dotnet new agent-web -n MyAgentApp -o MyAgentApp \
  --company "Contoso" \
  --version "0.2.0" \
  --templateToken "App" \
  --processIntent "Generate SaaS landing" \
  --processContext "{\"brand\":{\"name\":\"ACME\"}}" \
  --processReasoning "cot,tot,got" \
  --processIterations "1" \
  --processFeedback false
```

## Build and run
```sh
cd MyAgentApp
dotnet restore
dotnet build
# optional: run generator during build
# dotnet build -p:EnableProcessGenerator=true -p:ProcessFeedback=true

dotnet run --project src/ProjectName.Web
```
