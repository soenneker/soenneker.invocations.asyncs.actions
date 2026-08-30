using System.Threading;
using System.Threading.Tasks;
using Soenneker.Tests.Unit;

namespace Soenneker.Invocations.Asyncs.Actions.Tests;

public sealed class AsyncActionInvocationTests : UnitTest
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Invoke_passes_state_and_cancellation_token()
    {
        var observed = new ObservedInvocation();
        using var cancellation = new CancellationTokenSource();
        var invocation = new AsyncActionInvocation(static (state, token) =>
        {
            var value = (ObservedInvocation)state!;
            value.Count++;
            value.Token = token;
            return Task.CompletedTask;
        }, observed);

        await invocation.Invoke(cancellation.Token);

        await Assert.That(observed.Count).IsEqualTo(1);
        await Assert.That(observed.Token).IsEqualTo(cancellation.Token);
        await Assert.That(invocation.State).IsSameReferenceAs(observed);
    }

    private sealed class ObservedInvocation
    {
        public int Count { get; set; }
        public CancellationToken Token { get; set; }
    }
}
