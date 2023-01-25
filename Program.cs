namespace Reflection;
class Program
{
    public static void ShowAll(object obj)
    {
        var type = obj.GetType();
        foreach (var prop in type.GetProperties())
        {
            var getter = (prop.GetMethod == null) ? "" : prop.GetMethod.Name;
            var setter = (prop.SetMethod == null) ? "" : prop.SetMethod.Name;
            Console.WriteLine($"{prop.PropertyType} {prop.Name}: getter={getter}; setter={setter}");
        }
        foreach (var method in type.GetMethods())
        {
            var args = method.GetParameters().Select(x => $"{x.ParameterType} {x.Name}");
            Console.WriteLine($"{method.ReturnType.Name} {method.Name}({string.Join(", ", args)})");
        }
    }
    public static T CreateInstance<T>(T obj)
        => Activator.CreateInstance<T>();
    public static T? CreateInstance<T>(T obj, object[] args)
        => (T?)Activator.CreateInstance(typeof(T), args);
    public static object? CreateInstance(object obj)
        => Activator.CreateInstance(obj.GetType());
    public static object? CreateInstance(object obj, object[] args)
        => Activator.CreateInstance(obj.GetType(), args);
    static void Main(string[] args)
    {
        List<int> list = new List<int> {0, 1, 2};
        ShowAll(list);
        List<int> list1 = CreateInstance<List<int>>(list);
        List<int>? list2 = CreateInstance<List<int>>(list, (new object[] {new int[] {0, 1, 2}}));
        List<int> list3 = CreateInstance(list);
        List<int>? list4 = CreateInstance(list, (new object[] {new int[] {0, 1, 2}}));
    }
}
