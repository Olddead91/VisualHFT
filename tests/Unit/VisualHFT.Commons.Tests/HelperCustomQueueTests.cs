using System.Collections.Concurrent;

namespace VisualHFT.Commons.Tests;

public class HelperCustomQueueTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan PauseObservationTimeout = TimeSpan.FromMilliseconds(250);

    [Fact]
    public void PauseDuringBatch_PreservesFifoOrder()
    {
        var processed = new ConcurrentQueue<string>();
        var errors = new ConcurrentQueue<Exception>();
        using var processingFirstItem = new ManualResetEventSlim();
        using var releaseFirstItem = new ManualResetEventSlim();
        using var firstItemProcessed = new ManualResetEventSlim();
        using var allItemsProcessed = new CountdownEvent(3);

        using var queue = new HelperCustomQueue<string>(
            "fifo-pause-test",
            item =>
            {
                if (item == "A")
                {
                    processingFirstItem.Set();
                    if (!releaseFirstItem.Wait(TestTimeout, TestContext.Current.CancellationToken))
                        throw new TimeoutException("Timed out waiting to release the first item.");
                }

                processed.Enqueue(item);
                allItemsProcessed.Signal();

                if (item == "A")
                    firstItemProcessed.Set();
            },
            errors.Enqueue);

        queue.Add("A");
        Assert.True(processingFirstItem.Wait(TestTimeout, TestContext.Current.CancellationToken));

        queue.Add("B");
        queue.Add("C");
        queue.PauseConsumer();
        releaseFirstItem.Set();

        Assert.True(firstItemProcessed.Wait(TestTimeout, TestContext.Current.CancellationToken));
        Assert.False(allItemsProcessed.Wait(PauseObservationTimeout, TestContext.Current.CancellationToken));

        queue.ResumeConsumer();

        Assert.True(allItemsProcessed.Wait(TestTimeout, TestContext.Current.CancellationToken));
        Assert.Equal(new[] { "A", "B", "C" }, processed.ToArray());
        Assert.Equal(3, processed.Distinct().Count());
        Assert.Empty(errors);
    }

    [Fact]
    public void PauseBeforeEnqueue_DoesNotProcessUntilResume()
    {
        var processed = new ConcurrentQueue<int>();
        var errors = new ConcurrentQueue<Exception>();
        using var consumerStarted = new ManualResetEventSlim();
        using var anyItemProcessed = new ManualResetEventSlim();
        using var allItemsProcessed = new CountdownEvent(3);

        using var queue = new HelperCustomQueue<int>(
            "pause-before-enqueue-test",
            item =>
            {
                if (item == 0)
                {
                    consumerStarted.Set();
                    return;
                }

                processed.Enqueue(item);
                anyItemProcessed.Set();
                allItemsProcessed.Signal();
            },
            errors.Enqueue);

        queue.Add(0);
        Assert.True(consumerStarted.Wait(TestTimeout, TestContext.Current.CancellationToken));

        queue.PauseConsumer();
        queue.Add(1);
        queue.Add(2);
        queue.Add(3);

        Assert.False(anyItemProcessed.Wait(PauseObservationTimeout, TestContext.Current.CancellationToken));

        queue.ResumeConsumer();

        Assert.True(allItemsProcessed.Wait(TestTimeout, TestContext.Current.CancellationToken));
        Assert.Equal(new[] { 1, 2, 3 }, processed.ToArray());
        Assert.Equal(3, processed.Distinct().Count());
        Assert.Empty(errors);
    }
}
