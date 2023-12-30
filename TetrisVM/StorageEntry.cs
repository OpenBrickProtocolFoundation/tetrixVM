namespace TetrisVM;

public interface IStorageEntry
{
    void Display();
}

public abstract class StorageEntry<T> : IStorageEntry
{
    public T Value;
    public abstract void Display();
}