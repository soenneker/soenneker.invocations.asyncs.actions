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

    /// <summary>
    /// Gets state.
    /// </summary>
    public object? State { get; }

    public AsyncActionInvocation(Func<object?, CancellationToken, Task> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    /// <summary>
    /// Invokes the async action invocation with the supplied payload.
    /// </summary>
    /// <param name="ct">Ct for the invoke operation.</param>
    /// <returns>A task that completes when the callback has finished running.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task Invoke(CancellationToken ct = default) => _callback(State, ct);
}
