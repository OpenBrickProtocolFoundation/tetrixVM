namespace TetrisVM;

public class Storage
{
    public int Capacity { get; set; }
    private object[] _data;

    public Storage(int capacity = 100)
    {
        Capacity = capacity;
        _data = new object[capacity];
    }

    public object this[int index]
    {
        get
        {
            var data = _data[index];

            return data;
        }
        set
        {
            if (index > Capacity)
            {
                return;
            }

            _data[index] = value;
        }
    }

    public T Get<T>(int index)
    {
        var data = _data[index];

        if (data == null)
        {
            _data[index] = default(T);
        }

        return (T)_data[index];
    }
}