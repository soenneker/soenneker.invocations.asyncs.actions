using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Invocations.Asyncs.Actions;

/// <summary>
/// Deferred, stateful asynchronous action invocation without closure capture.
/// </summary>
public sealed class AsyncActionInvocation
{
    private readonly Func<object?, CancellationToken, Task> _callback;

    public object? State { get; }

    public AsyncActionInvocation(Func<object?, CancellationToken, Task> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task Invoke(CancellationToken ct = default) => _callback(State, ct);
}