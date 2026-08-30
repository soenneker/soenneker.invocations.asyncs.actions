[![](https://img.shields.io/nuget/v/soenneker.invocations.asyncs.actions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.actions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.actions/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.actions/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.actions/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.actions/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.asyncs.actions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.actions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.actions/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.actions/actions/workflows/codeql.yml)

# Soenneker.Invocations.Asyncs.Actions

Represents a deferred asynchronous action with explicit state and cancellation, allowing a static delegate to avoid closure allocation.

## Install

```bash
dotnet add package Soenneker.Invocations.Asyncs.Actions
```

## Usage

```csharp
using Soenneker.Invocations.Asyncs.Actions;

var job = new ExportJob("orders");

var invocation = new AsyncActionInvocation(
    static (state, cancellationToken) =>
        ((ExportJob)state!).Run(cancellationToken),
    job);

pending.Enqueue(invocation);

// Later:
AsyncActionInvocation next = pending.Dequeue();
await next.Invoke(cancellationToken);
```

`Invoke()` passes the stored `State` and caller-supplied token directly to the callback. Cancellation occurs only if the callback observes that token. The returned `Task` completes, faults, or cancels exactly as the callback does, and repeated calls invoke the callback again.

Use a `static` lambda or static method when avoiding closure capture matters. A capturing lambda remains valid but creates its own closure. Value-type state is boxed because state is stored as `object`.
