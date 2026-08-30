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
    /// Gets the state passed to the callback when <see cref="Invoke"/> is called.
    /// </summary>
    public object? State { get; }

    /// <summary>
    /// Creates a deferred asynchronous invocation from a callback and its explicit state.
    /// </summary>
    /// <param name="callback">The callback to invoke.</param>
    /// <param name="state">The state supplied to <paramref name="callback"/>.</param>
    public AsyncActionInvocation(Func<object?, CancellationToken, Task> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    /// <summary>
    /// Invokes the callback with <see cref="State"/> and the supplied cancellation token.
    /// </summary>
    /// <param name="ct">The token forwarded to the callback.</param>
    /// <returns>A task that completes when the callback has finished running.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task Invoke(CancellationToken ct = default) => _callback(State, ct);
}
