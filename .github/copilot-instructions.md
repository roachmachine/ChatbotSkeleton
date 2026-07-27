# Repository Instructions for GitHub Copilot

This repository should be treated as a production-grade .NET/Azure application unless explicitly stated otherwise.

## General Development Rules

- Prefer secure, simple, maintainable code.
- Use C# and .NET idioms.
- Prefer dependency injection.
- Prefer async APIs for I/O.
- Avoid hardcoded secrets.
- Avoid broad exception swallowing.
- Avoid logging sensitive values.
- Keep authentication and authorization explicit.
- Use configuration providers rather than embedded settings.
- Prefer Azure Managed Identity over connection strings and static keys when possible.
- Prefer Azure Key Vault for secrets.
- Validate all external input.
- Treat route values, query strings, headers, form fields, JSON bodies, uploaded files, and environment variables as untrusted.

## Security Default

When generating code:

- Add authorization where endpoints access user, organization, tenant, billing, scheduling, or administrative data.
- Validate model input server-side.
- Avoid returning internal exception details to callers.
- Avoid exposing stack traces.
- Avoid `AllowAnyOrigin` unless explicitly justified.
- Avoid raw SQL unless parameterized.
- Avoid file system access based directly on user input.
- Avoid disabling token validation.
- Avoid disabling TLS/certificate validation.
- Avoid storing secrets in `appsettings.json`.
- Avoid storing secrets in source control.