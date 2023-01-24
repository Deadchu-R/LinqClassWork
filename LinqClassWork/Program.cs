using System.Collections;
using System.Runtime.CompilerServices;

namespace LinqClassWork; 

class Program
{
    private static Check check = new Check();

    
    public static void Main(string[] args)
    {
        
        string s = "i have four words";
       Console.WriteLine("word count is " + s.WordCount()); 

            bool flag = false;
            Console.WriteLine("num is" + flag.ToInt());

            Test();


    }

    public static void Test()
    {
        check.Test();
    }
}

class Check
{
    public UniqeList<int> list = new UniqeList<int>();
    public  void Test()
  
    {
        list.Add(10);
        list.Add(1000);
        list.Add(15);
        list.Add(3);
        list.Add(7);

        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
    
    }
}

public class UniqeList<T>: IEnumerable<T>
{
    private List<T> list = new List<T>();

    private IEnumerable<T> _enumerableImplementation;
    public IEnumerator<T> GetEnumerator()
    {
        return new enumerableStruct<T>(list);
    }

    public void Add(T value)
    {
        list.Add(value);
        
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_enumerableImplementation).GetEnumerator();
    }
}

struct enumerableStruct<T>: IEnumerator<T>
{
    private List<T> _list;
    private int index = -1;
    public enumerableStruct(List<T> list)
    {
        _list = list;
    }

    public T Current => _list[index];

    public bool MoveNext()
    {
        index++;
        return index < _list.Count;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
       
    }
}

static class Extension
{
    public static int ToInt(this bool b)
    {
        int value;
        value = b == true ? 1 : 0;

        return value;
    }

    public static int WordCount(this string s)
    {
        char[] c = s.ToCharArray();
        string[] words = s.Split(' ');
        return words.Count();
    }

    public static void PlusSix(this ref int  i)
    {
        i = i + 6;
    }

}