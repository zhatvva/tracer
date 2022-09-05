using Tracer.Core.Services;
using Tracer.Core.Abstractions;
using System.Text.Json;

public class HelloWorld
{
    public static async Task Main(string[] args)
    { 
        var tracer = new TracerService();
        var foo = new Foo(tracer); 
        foo.MyMethod();
        var result = tracer.GetTraceResult();
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(result, options);
        Console.WriteLine(json);
        Console.ReadLine();
    }
}

public class Foo
{
    private Bar _bar;
    private ITracer _tracer;

    internal Foo(ITracer tracer)
    {
        _tracer = tracer;
        _bar = new Bar(_tracer);
    }

    public void MyMethod()
    {
        _tracer.StartTrace();
        Console.WriteLine(Environment.CurrentManagedThreadId);
        Thread.Sleep(100);
        var task = Task.Run(_bar.M1);
        _bar.M2();
        task.Wait();
        Console.WriteLine(Environment.CurrentManagedThreadId);
        _tracer.StopTrace();
    }
}

public class Bar
{
    private ITracer _tracer;

    internal Bar(ITracer tracer)
    {
        _tracer = tracer;
    }

    public void M1()
    {
        _tracer.StartTrace();
        Thread.Sleep(100);
        _tracer.StopTrace();
    }

    public void M2()
    {
        _tracer.StartTrace();
        Thread.Sleep(70);
        _tracer.StopTrace();
    }
}
