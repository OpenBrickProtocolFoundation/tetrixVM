using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class SleepFunction : Callable<object, byte>
{
    protected override object Call(byte ms)
    {
        Thread.Sleep(ms);
        return null;
    }
}