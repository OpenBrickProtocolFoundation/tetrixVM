namespace TetrisVM.Instructions;

public interface ICallable
{
    void Call(VirtualMaschine vm);
}

public class FuncCall(Action<VirtualMaschine> callback) : ICallable
{
    private Action<VirtualMaschine> callback = callback;

    public void Call(VirtualMaschine vm)
    {
        callback.Invoke(vm);
    }
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