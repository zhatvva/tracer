using Tracer.Core.Services;
using Tracer.Core.Tests.Models.MultipleThreads;
using Tracer.Core.Tests.Models.SingleThread;
using Xunit;

namespace Tracer.Core.Tests
{
    public class TracerServiceTests
    {
        [Fact]
        public void SingleThread()
        {
            var tracer = new TracerService();
            var foo = new FooSingleThread(tracer);
            
            foo.MyMethod();
            var result = tracer.GetTraceResult();

            Assert.NotNull(result);
            Assert.NotNull(result.Threads);
            Assert.Equal(1, result.Threads.Count);
            Assert.NotNull(result.Threads[0].Methods);
            Assert.Equal(1, result.Threads[0].Methods.Count);
            Assert.NotNull(result.Threads[0].Methods[0].Methods);
            Assert.Equal(2, result.Threads[0].Methods[0].Methods.Count);
            Assert.NotNull(result.Threads[0].Methods[0].Methods[0].Methods);
            Assert.NotNull(result.Threads[0].Methods[0].Methods[1].Methods);
            Assert.Equal(0, result.Threads[0].Methods[0].Methods[0].Methods.Count);
            Assert.Equal(0, result.Threads[0].Methods[0].Methods[1].Methods.Count);

            Assert.Equal("MyMethod", result.Threads[0].Methods[0].Name);
            Assert.Equal("FooSingleThread", result.Threads[0].Methods[0].Class);
            Assert.Equal("M1", result.Threads[0].Methods[0].Methods[0].Name);
            Assert.Equal("BarSingleThread", result.Threads[0].Methods[0].Methods[0].Class);
            Assert.Equal("M2", result.Threads[0].Methods[0].Methods[1].Name);
            Assert.Equal("BarSingleThread", result.Threads[0].Methods[0].Methods[1].Class);

            Assert.True(result.Threads[0].TimeInMs >= 270);
            Assert.True(result.Threads[0].Methods[0].TimeInMs >= 270);
            Assert.True(result.Threads[0].Methods[0].Methods[0].TimeInMs >= 100);
            Assert.True(result.Threads[0].Methods[0].Methods[1].TimeInMs >= 70);
        }

        [Fact]
        public void MultipleThreads()
        {
            var tracer = new TracerService();
            var foo = new FooMultipleThreads(tracer);

            foo.MyMethod();
            var result = tracer.GetTraceResult();

            Assert.NotNull(result);
            Assert.NotNull(result.Threads);
            Assert.Equal(2, result.Threads.Count);
            Assert.NotNull(result.Threads[0].Methods);
            Assert.NotNull(result.Threads[1].Methods);
            Assert.Equal(1, result.Threads[0].Methods.Count);
            Assert.Equal(1, result.Threads[1].Methods.Count);
            Assert.NotNull(result.Threads[0].Methods[0].Methods);
            Assert.Equal(1, result.Threads[0].Methods[0].Methods.Count);
            Assert.NotNull(result.Threads[1].Methods[0].Methods);
            Assert.Equal(0, result.Threads[1].Methods[0].Methods.Count);
            Assert.NotNull(result.Threads[0].Methods[0].Methods[0].Methods);
            Assert.Equal(0, result.Threads[0].Methods[0].Methods[0].Methods.Count);

            Assert.Equal("MyMethod", result.Threads[0].Methods[0].Name);
            Assert.Equal("FooMultipleThreads", result.Threads[0].Methods[0].Class);
            Assert.Equal("M2", result.Threads[0].Methods[0].Methods[0].Name);
            Assert.Equal("BarMultipleThreads", result.Threads[0].Methods[0].Methods[0].Class);
            Assert.Equal("M1", result.Threads[0].Methods[0].Name);
            Assert.Equal("BarMultipleThreads", result.Threads[0].Methods[0].Class);

            Assert.True(result.Threads[0].TimeInMs >= 170);
            Assert.True(result.Threads[0].Methods[0].TimeInMs >= 170);
            Assert.True(result.Threads[0].Methods[0].Methods[0].TimeInMs >= 70);
            Assert.True(result.Threads[1].TimeInMs >= 100);
            Assert.True(result.Threads[1].Methods[0].TimeInMs >= 100);
        }
    }
}