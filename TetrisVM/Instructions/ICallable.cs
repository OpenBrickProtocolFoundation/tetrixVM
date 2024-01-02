namespace TetrisVM.Instructions;

public interface ICallable
{
    void Call(VirtualMaschine vm);
}

public class AutoFunc(Delegate callback) : ICallable
{
    public Delegate Callback { get; } = callback;

    public void Call(VirtualMaschine vm)
    {
        var args = new List<object>();
        Prepare(args, vm);

        var result = callback.DynamicInvoke(args.ToArray());

        if (result != null && callback.Method.ReturnType.Name != "Void")
        {
            vm.Stack.Push(result);
        }
    }

    private void Prepare(ICollection<object> args, VirtualMaschine vm)
    {
        for (var index = 0; index < callback.Method.GetParameters().Length; index++)
        {
            args.Add(vm.Stack.Pop());
        }
    }
}

public abstract class Callable<TReturn> : ICallable
{
    protected abstract TReturn Call();
    protected VirtualMaschine vm;
    public void Call(VirtualMaschine vm)
    {
        this.vm = vm;
        var result = Call();

        PushResult(vm, result);
    }

    public static void PushResult(VirtualMaschine vm, TReturn result)
    {
        if (result != null && typeof(TReturn).Name != "Void")
        {
            vm.Stack.Push(result);
        }
    }
}

public abstract class Callable<TReturn, TArg> : ICallable
{
    protected VirtualMaschine vm;
    protected abstract TReturn Call(TArg arg);

    public void Call(VirtualMaschine vm)
    {
        this.vm = vm;
        var result = Call((TArg)vm.Stack.Pop());

        Callable<TReturn>.PushResult(vm, result);
    }
}

public abstract class Callable<TReturn, TArg1, TArg2> : ICallable
{
    protected VirtualMaschine vm;
    protected abstract TReturn Call(TArg1 arg1, TArg2 arg2);

    public void Call(VirtualMaschine vm)
    {
        this.vm = vm;
        var result = Call((TArg1)vm.Stack.Pop(), (TArg2)vm.Stack.Pop());

        Callable<TReturn>.PushResult(vm, result);
    }
}

public abstract class Callable<TReturn, TArg1, TArg2, TArg3> : ICallable
{
    protected VirtualMaschine vm;
    protected abstract TReturn Call(TArg1 arg1, TArg2 arg2, TArg3 arg3);

    public void Call(VirtualMaschine vm)
    {
        this.vm = vm;
        var result = Call((TArg1)vm.Stack.Pop(), (TArg2)vm.Stack.Pop(), (TArg3)vm.Stack.Pop());

        Callable<TReturn>.PushResult(vm, result);
    }
}