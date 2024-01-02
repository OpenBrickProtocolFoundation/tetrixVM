using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class SleepFunction : ICallable
{
    public void Call(VirtualMaschine vm)
    {
        var ms = (byte) vm.Stack.Pop();
        
        Thread.Sleep(ms);
    }
}