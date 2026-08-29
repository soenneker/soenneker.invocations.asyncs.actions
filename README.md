[![](https://img.shields.io/nuget/v/soenneker.invocations.asyncs.actions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.actions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.actions/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.actions/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.asyncs.actions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.actions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.actions/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.actions/actions/workflows/codeql.yml)

# Soenneker.Invocations.Asyncs.Actions

Deferred, stateful asynchronous action invocation without closure capture.

## Install

```bash
dotnet add package Soenneker.Invocations.Asyncs.Actions
```

## What you get

- `AsyncActionInvocation` — Deferred, stateful asynchronous action invocation without closure capture.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AsyncActionInvocation.State` | Gets state. | Gets state. |
| `AsyncActionInvocation.Invoke(ct)` | Invokes the async action invocation with the supplied payload. | A task that completes when the callback has finished running. |
