namespace ConsoleApp14;

class MyList<T>
{
    T[] values;

    static int _count = 0;

    static int _capacity = 4;

    public MyList()
    {
        values = new T[_capacity];
    }


    public void Add(T item)
    {

        if (_count >= _capacity)
        {
            _capacity *= 2;
            T[] newArr = new T[_capacity];

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = values[i];
            }
            values = newArr;
        }
        values[_count++] = item;
    }

    public T Find(Predicate<T> predicate)
    {
        for (int i = 0; i < _count; i++)
        {
            if (predicate(values[i]))
            {
                return values[i];
            }

        }
        return default(T);
    }


    public T[] FindAll(Predicate<T> predicate)
    {
        T[] newArr = new T[_count];
        for (int i = 0; i < _count; i++)
        {
            if (predicate(values[i]))
            {
                newArr[i] = values[i];
            }
        }



        return newArr;
    }


    public void Remove(T item)
    {
        T[] newArr = new T[_capacity];

        for (int i = 0; i < _count; i++)
        {
            if (Equals(values[i], item))
            {
                continue;
            }
            newArr[i] = values[i];
        }
       
        values = newArr;
        _count--;
    }

    public void RemoveAll(Predicate<T> predicate)
    {
        T[] newArr = new T[_count];
        for (int i = 0; i < _count; i++)
        {
            if (predicate(values[i]))
            {
                continue;
            }
            newArr[i] = values[i];

        }
        values = newArr;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Invalid index");
            return values[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Invalid index");
            values[index] = value;
        }
    }
    public int Length()
    {
        return _count;
    }
}
